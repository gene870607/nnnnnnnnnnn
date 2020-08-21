using Storyteller.DBModels;
using Storyteller.Repository;
using Storyteller.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyteller.Services
{
    public class HomeService
    {
        private readonly HomeRepository _homeRepository;
        public HomeService(HomeRepository homedao)
        {
            _homeRepository = homedao;
        }

        public HomeViewModel GetHomeViewModel()
        {


            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.HomeScriptCategory = _homeRepository.GetHomeScriptCategory();
            homeViewModel.NewScripts = _homeRepository.GetHomeNewScripts();
            homeViewModel.TopUser = _homeRepository.GetHomeTopUser();
            homeViewModel.TopScript = _homeRepository.GetHomeTopScript();

            return homeViewModel;
        }

        public IEnumerable<AchievementViewModel> GetAchievement(string UserID)
        {
            return _homeRepository.GetAchievement(UserID);
        }

        public IEnumerable<CategoryViewModel> GetCategoryScript(string categoryID)
        {
            return _homeRepository.GetCategoryScript(categoryID);
        }

        public IEnumerable<ScriptViewModel> GetScript(string scriptID)
        {
            return _homeRepository.GetScript(scriptID);
        }

        public void ViewToModel(UserViewModel UVM)
        {
            var UserData = new User()
            {
                UserId = UVM.UserId.ToString(),
                UserName = UVM.UserName,
                UserImg = UVM.UserImg,
            };
            _homeRepository.CreateUser(UserData);
        }
    }
}
