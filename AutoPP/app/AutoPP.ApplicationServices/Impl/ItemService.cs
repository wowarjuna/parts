using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using SharpArch.Core.PersistenceSupport;
using AutoPP.Core.RepositoryInterfaces;
using AutoPP.ApplicationServices.Exceptions;
using AutoPP.ApplicationServices.Util;
using System.IO;

namespace AutoPP.ApplicationServices.Impl
{
    public class ItemService : IItemsService
    {
        private IRepository<Category> _rCategory;
        private IItemRepository _rItem;
        private IRepository<Make> _rMake;
        private IGalleryRepository _rGallery;
        private IRepository<Model> _rModel;

        public ItemService(IRepository<Category> rCategory, IItemRepository rItem, IGalleryRepository rGallery, 
            IRepository<Make> rMake, IRepository<Model> rModel)
        {
            _rCategory = rCategory;
            _rItem = rItem;
            _rGallery = rGallery;
            _rMake = rMake;
            _rModel = rModel;
        }

        #region IItemsService Members

        public Item Get(int ItemId)
        {
            return _rItem.Get(ItemId);
        }

        public void Add(Item item)
        {
            item.Galleries.Add(new Gallery { Name = "Default", Item = item });
            _rItem.SaveOrUpdate(item);
            _rItem.DbContext.CommitChanges();
        }

        public IList<Make> GetMakes()
        {
            return this._rMake.GetAll().ToList<Make>();
        }

        public List<Category> GetCategories(int Parent)
        {
            return this._rCategory.GetAll().Where(x => x.Parent == Parent).ToList<Category>();
        }

        public List<Category> GetCategories(List<int> Ids)
        {
            var _results = from _category in this._rCategory.GetAll()
                   where Ids.Contains(_category.Id)
                   select _category;
            return _results.ToList<Category>();
        }


        public void AddGallery(Gallery gallery)
        {
            _rGallery.SaveOrUpdate(gallery);
            _rGallery.DbContext.CommitChanges();
        }

        public void AddGalleryMedia(Gallery gallery, Media resource)
        {
            if (_rGallery.Get(gallery.GalleryId) == null)
                throw new GalleryException();
            if (GetFiles(gallery.GalleryId).Count == int.Parse(SystemSetting.Instance.Settings()["ITEMS_PER_GALLERY"]))
                throw new GalleryException(string.Format("Maximum number of items {0}", SystemSetting.Instance.Settings()["ITEMS_PER_GALLERY"]));
            UploadMedia(gallery.GalleryId, resource);
        }

        private List<Media> GetFiles(Guid FolderId)
        {
            List<Media> _result = new List<Media>();
            var _files = Directory.GetFiles(string.Format("{0}{1}\\",SystemSetting.Instance.Settings()["GALLERY_FOLDER_PATH"], FolderId.ToString()));
            foreach(var _file in _files)
                _result.Add(new Media { FileName = _file });
            return _result;
        }

        private void UploadMedia(Guid FolderId, Media resource)
        {
            try
            {
                FileStream fs = null;
                
                using (fs = new FileStream(string.Format("{0}{1}\\{2}", SystemSetting.Instance.Settings()["GALLERY_FOLDER_PATH"], FolderId.ToString(), resource.FileName), 
                    FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    const int bufferLen = 1024; //read stream @ 4K chunks
                    byte[] buffer = new byte[bufferLen];

                    int bytesRead = 0;
                    while ((bytesRead = resource.FileStream.Read(buffer, 0, bufferLen)) > 0)
                    {
                        fs.Write(buffer, 0, bytesRead);
                        
                    }

                    fs.Close();
                    resource.FileStream.Close();
                                        
                    return;
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }


        public IList<Media> GetGallleryResources(Gallery gallery)
        {
            throw new NotImplementedException();
        }

        public Make GetMake(int Make)
        {
            return _rMake.Get(Make);
        }

        public ItemResponse GetItems(ItemParameters paramters)
        {
            int _category = int.Parse(paramters.Criterias["category"]);
            int _make = int.Parse(paramters.Criterias["make"]);
            ItemResponse _result = new ItemResponse();
            int _count = 0;
            _result.Items = this._rItem.GetItems(f => ((paramters.FreeSearch != null ? 
                (f.Description.Contains(paramters.FreeSearch) || f.Name.Contains(paramters.FreeSearch)) : true)
                && (!_category.Equals(0) ? f.Categories.Any( c => c.Id.Equals(_category)) : true)
                && (!_make.Equals(0) ? f.Make.Id.Equals(_make) : true)),
                paramters.StartIndex, paramters.PageSize, out _count).ToList<Item>();
            
            _result.Count = _count;
            return _result;
        }

        public void UpdateGallery(Gallery Gallery)
        {
            _rGallery.SaveOrUpdate(Gallery);
            _rGallery.DbContext.CommitChanges();
        }

        public IList<Model> GetModels(List<int> Ids)
        {
            var _results = from _model in this._rModel.GetAll()
                           where Ids.Contains(_model.Id)
                           select _model;
            return _results.ToList<Model>();
        }

        public void Delete(int ItemId)
        {
            var _item = _rItem.Get(ItemId);
            _rItem.Delete(_item);
            _rItem.DbContext.CommitChanges();
        }

        public ModelResponse GetModels(ModelRequest request)
        {
           var _data = _rModel.GetAll().Where( m => !request.Filters["Model"].Equals(0) ?  m.Make.Id.Equals(request.Filters["Model"]) : true);
           return new ModelResponse { Models = _data.Skip(request.StartFrom).Take(request.Offset).ToList() , Count = _data.Count<Model>() };
        }

        public void AddModel(ModelRequest request)
        {
            _rModel.SaveOrUpdate(request.Model);
        }

        public void DeleteModel(ModelRequest request)
        {
            _rModel.Delete(_rModel.Get(request.ModelId));
            _rModel.DbContext.CommitChanges();
        }

        public void UpdateModel(ModelRequest request)
        {
            _rModel.SaveOrUpdate(request.Model);
            _rModel.DbContext.CommitChanges();
        }

        public Model GetModel(int Id)
        {
            return _rModel.Get(Id);
        }


        public void Update(Item Item)
        {
            _rItem.SaveOrUpdate(Item);
            _rItem.DbContext.CommitChanges();
        }

        #endregion

       
    }
}
