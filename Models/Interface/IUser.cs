using BrainStorm.Models;
using System.Collections.Generic;


namespace Tutorial.Controllers.Interface
{
    public interface IUser
    {
        List<BrainStormUser> GetAllUsers();
        List<BrainStormUser> GetUserById(string Id);

        List<Article> GetUserArticles();
        Article GetUserArticleById();
    }
}
