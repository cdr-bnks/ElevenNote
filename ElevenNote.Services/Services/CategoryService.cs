using ElevenNote.Data;
using ElevenNote.Models._11CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services.Services
{
   public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                        new Category()
                        {
                            OwnerId = _userId,
                            Subject = model.Subject
                        };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                            ctx
                                .Categories
                                .Where(e => e.OwnerId == _userId)
                                .Select(
                                        e =>
                                        new CategoryListItem
                                        {
                                            CategoryId = e.CategoryId,
                                            Subject = e.Subject,
                                            FavoriteCategory = e.FavoriteCategory,

                                        });

                return query.ToArray();
            }
        }

        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                            ctx
                                .Categories
                                .Single(e => e.CategoryId == id && e.OwnerId == _userId);
                return
                    new CategoryDetail
                    {
                        CatergoryId = entity.CategoryId,
                        Subject = entity.Subject,
                        FavoriteCatagory = entity.FavoriteCategory
                    };
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                            ctx
                                .Categories
                                .Single(e => e.CategoryId == model.CategoryId && e.OwnerId == _userId);

                entity.Subject = model.Subject;
                entity.FavoriteCategory = model.FavorityCategory;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                            ctx
                                .Categories
                                .Single(e => e.CategoryId == categoryId && e.OwnerId == _userId);
                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
