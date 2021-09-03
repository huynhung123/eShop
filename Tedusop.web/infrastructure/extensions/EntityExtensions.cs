using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tedusop.Model.Models;
using Tedusop.web.Models;

namespace Tedusop.web.infrastructure.extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Description = postCategoryVm.Description;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Image = postCategoryVm.Image;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;
        }
        public static void UpdatePost(this Post post, PostViewModel posVm)
        {
            post.ID = posVm.ID;
            post.Name = posVm.Name;
            post.Description = posVm.Description;
            post.Alias = posVm.Alias;
            post.CategoryID = posVm.CategoryID;
            post.Content = posVm.Content;
            post.Image = posVm.Image;
            post.HomeFlag = posVm.HomeFlag;
            post.ViewCount = posVm.ViewCount;
        }
        public static void updateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryViewModel)
        {
            productCategory.ID = productCategoryViewModel.ID;
            productCategory.Name = productCategoryViewModel.Name;
            productCategory.Alias = productCategoryViewModel.Alias;
            productCategory.Description = productCategoryViewModel.Description;
            productCategory.parentID = productCategoryViewModel.parentID;
            productCategory.DisplayOder = productCategoryViewModel.DisplayOder;
            productCategory.Image = productCategoryViewModel.Image;
            productCategory.HomeFlang = productCategoryViewModel.HomeFlang;
            productCategory.CreatedDate = productCategoryViewModel.CreatedDate;
            productCategory.CreatedBy = productCategoryViewModel.CreatedBy;
            productCategory.UpdatedDate = productCategoryViewModel.UpdatedDate;
            productCategory.UpdateBy = productCategoryViewModel.UpdateBy;
            productCategory.MetaKeyword = productCategoryViewModel.MetaKeyword;
            productCategory.MetaDescription = productCategoryViewModel.MetaDescription;
            productCategory.Status = productCategoryViewModel.Status;
            




        }
    }
}