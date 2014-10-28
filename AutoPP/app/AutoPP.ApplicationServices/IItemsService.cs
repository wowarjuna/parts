using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using AutoPP.ApplicationServices.Util;

namespace AutoPP.ApplicationServices
{
    public interface IItemsService
    {
        Item Get(int ItemId);
        void Add(Item item);
        void Update(Item Item);
        
        List<Category> GetCategories(int Parent);
        List<Category> GetCategories(List<int> Ids);
        IList<Make> GetMakes();
        Make GetMake(int Make);
        void AddGallery(Gallery gallery);
        //void AddGalleryMedia(Gallery gallery, Media resource);
        //IList<Media> GetGallleryResources(Gallery gallery);
        ItemResponse GetItems(ItemParameters paramters);
        void UpdateGallery(Gallery Gallery);
        IList<Model> GetModels(List<int> Ids);
        void Delete(int ItemId);
        ModelResponse GetModels(ModelRequest request);
        void AddModel(ModelRequest request);
        void DeleteModel(ModelRequest request);
        void UpdateModel(ModelRequest request);
        Model GetModel(int Id);

        
        
    }


}
