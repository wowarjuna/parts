using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Automapping;

namespace AutoPP.Data.NHibernateMaps
{
    
    public class ItemMap : IAutoMappingOverride<Item>
    {
        #region IAutoMappingOverride<Item> Members

        public void Override(AutoMapping<Item> map)
        {
            map.Table("Item");
            map.Id(x => x.Id, "Id").UnsavedValue(0).GeneratedBy.Identity();
            map.Map(x => x.Name, "Name");
            map.Map(x => x.Description, "Description");
            map.Map(x => x.VendorMeta, "VendorMeta");
            map.Map(x => x.NoOfHits, "NoOfHits");
            map.Map(x => x.ModifiedOn, "ModifiedOn");
            map.HasManyToMany<Category>(x => x.Categories).Table("ItemsInCategories").ParentKeyColumn("ItemId").ChildKeyColumn("CategoryId").Cascade.All();
            map.HasManyToMany<Model>(x => x.Models).Table("ItemsInModels").ParentKeyColumn("ItemId").ChildKeyColumn("ModelId");
            //map.HasMany<Gallery>(x => x.Galleries).KeyColumn("ItemId").Cascade.SaveUpdate();
            map.References<Make>(x => x.Make).Column("MakeId");
            map.References<Vendor>(x => x.Vendor).Column("VendorId");
           
        }

        #endregion
    }

    public class CategoryMap : IAutoMappingOverride<Category>
    {
        #region IAutoMappingOverride<Category> Members

        public void Override(AutoMapping<Category> map)
        {
            map.Table("Category");
            map.Id(x => x.Id, "Id").UnsavedValue(0).GeneratedBy.Identity();
            map.Map(x => x.Name, "Name");
            map.Map(x => x.Parent, "ParentId");
            map.HasMany<Category>(x => x.Subs).KeyColumn("ParentId");
        }

        #endregion
    }

    public class GalleryMap : IAutoMappingOverride<Gallery>
    {

        #region IAutoMappingOverride<Gallery> Members

        public void Override(AutoMapping<Gallery> mapping)
        {
            mapping.Table("Galleries");
            mapping.IgnoreProperty(x => x.Id);
            mapping.Id(x => x.GalleryId, "GalleryId").GeneratedBy.GuidComb().UnsavedValue(new Guid());
            mapping.Map(x => x.Name, "Name");
            //mapping.Map(x => x.ItemId, "ItemId");
            mapping.References<Item>(x => x.Item).Column("ItemId");
        }



        #endregion
    }

    public class MakeMap : IAutoMappingOverride<Make>
    {

        #region IAutoMappingOverride<Make> Members

        public void Override(AutoMapping<Make> mapping)
        {
            mapping.Table("Make");
            mapping.HasMany<Model>(x => x.Models).KeyColumn("MakeId");
        }
        #endregion
    }

    public class ModelMap : IAutoMappingOverride<Model>
    {
        #region IAutoMappingOverride<Model> Members

        public void Override(AutoMapping<Model> mapping)
        {
            mapping.Table("Model");
            mapping.Id(x => x.Id, "Id").UnsavedValue(0).GeneratedBy.Identity();
            mapping.References<Make>(x => x.Make).Column("MakeId");
        }

        #endregion
    }
     
    
}
