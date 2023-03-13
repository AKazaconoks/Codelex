using LatvijasPasts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataLibrary;
using DataLibrary.BusinessLogic;
using static DataLibrary.BusinessLogic.CvProcessor;
using EducationDataModel = LatvijasPasts.Models.EducationDataModel;
using LanguageDataModel = LatvijasPasts.Models.LanguageDataModel;
using PrimaryDataModel = LatvijasPasts.Models.PrimaryDataModel;
using WorkplaceDataModel = LatvijasPasts.Models.WorkplaceDataModel;
using WorkplaceSkillDataModel = LatvijasPasts.Models.WorkplaceSkillDataModel;
using DataLibrary.DataAccess;

namespace LatvijasPasts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CvCreation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CvCreation(PrimaryDataModel model)
        {
            if (ModelState.IsValid)
            {
                var recordsCreated = CreatePrimaryData(model.FirstName, model.LastName, model.PhoneNumber,
                    model.EmailAddress);
                return RedirectToAction("EducationCreation");
            }

            return View();
        }

        public IActionResult EducationCreation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EducationCreation(EducationDataModel model, string button)
        {
            if (ModelState.IsValid)
            {
                var recordsCreated = CreateEducationData(model.EducationName, model.EducationFaculty,
                    model.EducationDirection, model.EducationLevel, model.EducationStatus, GetLastInsertedId("PrimaryData"));
                return button == "add" ? RedirectToAction("EducationCreation") : RedirectToAction("WorkplaceCreation");
            }

            return View();
        }

        public IActionResult WorkplaceCreation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WorkplaceCreation(WorkplaceDataModel model)
        {
                if (ModelState.IsValid)
            {
                var recordsCreated = CreateWorkplaceData(GetLastInsertedId("PrimaryData"), model.WorkplaceName, model.WorkplaceTitle,
                    model.WorkplaceTenure);
                return RedirectToAction("WorkplaceSkillCreation");
            }

            return View();
        }

        public IActionResult WorkplaceSkillCreation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WorkplaceSkillCreation(WorkplaceSkillDataModel model, string button)
        {
            if (ModelState.IsValid)
            {
                var recordsCreated =
                    CreateWorkplaceSkillData(model.SkillDescription, model.SkillType, GetLastInsertedId("WorkplaceData"));
                return button == "add" ? RedirectToAction("WorkplaceSkillCreation") : button == "continue" ? RedirectToAction("LanguageCreation") : RedirectToAction("WorkplaceCreation");
            }

            return View();
        }

        public IActionResult LanguageCreation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LanguageCreation(LanguageDataModel model, string button)
        {
            if (ModelState.IsValid)
            {
                var recordsCreated = CreateLanguageData(model.Language, GetLastInsertedId("PrimaryData"));
                return button == "add" ? RedirectToAction("LanguageCreation") : RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult ViewCvs()
        {
            var data = LoadData<PrimaryDataModel>("PrimaryData");
            var primaryData = new List<PrimaryDataModel>();

            foreach (var row in data)
            {
                primaryData.Add(new PrimaryDataModel
                {
                    Id = row.Id,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    PhoneNumber = row.PhoneNumber
                });
            }

            return View(primaryData);
        }

        public IActionResult ViewDetailedCv(int id)
        {
            var detailedView = new DetailedCvViewModel();
            var primaryDataList = LoadData<DataLibrary.Models.PrimaryDataModel>("PrimaryData");
            var primaryData = new DataLibrary.Models.PrimaryDataModel();
            foreach (var row in primaryDataList.Where(row => row.Id == id))
            {
                primaryData.Id = row.Id;
                primaryData.FirstName = row.FirstName;
                primaryData.LastName = row.LastName;
                primaryData.EmailAddress = row.EmailAddress;
                primaryData.PhoneNumber = row.PhoneNumber;
            }

            detailedView.PrimaryData = primaryData;


            var educationDataList = LoadData<DataLibrary.Models.EducationDataModel>("EducationData");
            var educationData = new List<DataLibrary.Models.EducationDataModel>();
            foreach (var row in educationDataList.Where(row => row.PrimaryDataId == id))
            {
                educationData.Add(new DataLibrary.Models.EducationDataModel
                {
                    EducationName = row.EducationName,
                    EducationDirection = row.EducationDirection,
                    EducationFaculty = row.EducationFaculty,
                    EducationLevel = row.EducationLevel,
                    EducationStatus = row.EducationStatus
                });
            }

            detailedView.EducationData = educationData;

            var workplaceDataList = LoadData<DataLibrary.Models.WorkplaceDataModel>("WorkplaceData");
            var workplaceData = new List<DataLibrary.Models.WorkplaceDataModel>();
            var workplaceIdList = new List<int>();
            foreach (var row in workplaceDataList.Where(row => row.PrimaryDataId == id))
            {
                workplaceData.Add(new DataLibrary.Models.WorkplaceDataModel
                {
                    Id = row.Id,
                    WorkplaceName = row.WorkplaceName,
                    WorkplaceTenure = row.WorkplaceTenure,
                    WorkplaceTitle = row.WorkplaceTitle
                });
                workplaceIdList.Add(row.Id);
            }

            detailedView.WorkplaceData = workplaceData;

            var workplaceSkillDataList = LoadData<DataLibrary.Models.WorkplaceSkillDataModel>("WorkplaceSkillData");
            var workplaceSkillData = new List<DataLibrary.Models.WorkplaceSkillDataModel>();
            foreach (var row in workplaceSkillDataList.Where(row => workplaceIdList.Contains(row.WorkplaceId)))
            {
                workplaceSkillData.Add(new DataLibrary.Models.WorkplaceSkillDataModel
                {
                    WorkplaceId = row.WorkplaceId,
                    SkillDescription = row.SkillDescription,
                    SkillType = row.SkillType
                });
            }

            detailedView.WorkplaceSkillData = workplaceSkillData;

            var languageDataList = LoadData<DataLibrary.Models.LanguageDataModel>("LanguageData");
            var languageData = new List<DataLibrary.Models.LanguageDataModel>();
            foreach (var row in languageDataList.Where(row => row.PrimaryDataId == id))
            {
                languageData.Add(new DataLibrary.Models.LanguageDataModel()
                {
                    Language = row.Language
                });
            }

            detailedView.LanguageData = languageData;

            return View(detailedView);
        }

        public IActionResult DeleteCv(int id)
        {
            DeletePrimaryData(id);
            return View();
        }

        public IActionResult Edit(int id)
        {
            var detailedView = new DetailedCvViewModel();
            var primaryDataList = LoadData<DataLibrary.Models.PrimaryDataModel>("PrimaryData");
            var primaryData = primaryDataList.FirstOrDefault(row => row.Id == id);
            detailedView.PrimaryData = primaryData;

            var educationDataList = LoadData<DataLibrary.Models.EducationDataModel>("EducationData");
            var educationData = educationDataList.Where(row => row.PrimaryDataId == id).ToList();
            detailedView.EducationData = educationData;

            var workplaceDataList = LoadData<DataLibrary.Models.WorkplaceDataModel>("WorkplaceData");
            var workplaceData = workplaceDataList.Where(row => row.PrimaryDataId == id).ToList();
            detailedView.WorkplaceData = workplaceData;

            var workplaceSkillDataList = LoadData<DataLibrary.Models.WorkplaceSkillDataModel>("WorkplaceSkillData");
            var workplaceSkillData = workplaceSkillDataList.Where(row => workplaceData.Select(w => w.Id).Contains(row.WorkplaceId)).ToList();
            detailedView.WorkplaceSkillData = workplaceSkillData;

            var languageDataList = LoadData<DataLibrary.Models.LanguageDataModel>("LanguageData");
            var languageData = languageDataList.Where(row => row.PrimaryDataId == id).ToList();
            detailedView.LanguageData = languageData;

            return View(detailedView);

        }

        [HttpPost]
        public IActionResult Edit(DetailedCvViewModel model)
        {
            if (ModelState.IsValid)
            {
                var primaryData = model.PrimaryData;
                var educationData = model.EducationData;
                var workplaceData = model.WorkplaceData;
                var workplaceSkillData = model.WorkplaceSkillData;
                var languageData = model.LanguageData;

                UpdateData("PrimaryData", primaryData);

                foreach (var education in educationData)
                {
                    UpdateData("EducationData", education);
                }

                foreach (var workplace in workplaceData)
                {
                    UpdateData("WorkplaceData", workplace);
                }

                foreach (var skill in workplaceSkillData)
                {
                    UpdateData("WorkplaceSkillData", skill);
                }

                foreach (var language in languageData)
                {
                    UpdateData("LanguageData", language);
                }

                return RedirectToAction("ViewCvs");
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}