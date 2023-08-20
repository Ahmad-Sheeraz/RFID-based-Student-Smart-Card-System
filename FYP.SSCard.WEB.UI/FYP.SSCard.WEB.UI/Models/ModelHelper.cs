using FYP.SSCard.WEB.UI.Models.Documents;
using FYP.SSCard.WEB.UI.Models.Students;
using StudentSmartCard;
using StudentSmartCard.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.SSCard.WEB.UI.Models
{
    public static class ModelHelper
    {
        public static List<SelectListItem> ToselectListItems(this IEnumerable<IListable> listablesList)
        {
            List<SelectListItem> itemsList = new List<SelectListItem>();
            foreach (var cat in listablesList)
            {
                itemsList.Add(new SelectListItem { Text = cat.Name, Value = Convert.ToString(cat.Id) });
            }
            return itemsList;
        }
        public static DocumentsModel ToDocModel(this Document entity)
        {
            DocumentsModel model = new DocumentsModel
            {
                Id = entity.Id,
                Imageupload = "~/Images/image.jpg",
                StudentRollno = entity.StuRollNo,
                Board = entity.Board,
                PassingYear = entity.PassingYear,
                Subject = entity.Subjects,
                TotalMarks = entity.TotalMarks,
                ObtainMarks = entity.ObtainMarks,
                // QualificationCategories = entity.QualCategory

            };
            if (!string.IsNullOrWhiteSpace(entity.Imageupload))
            {
                model.Imageupload = entity.Imageupload;
            }
            return model;
        }
        public static List<DocumentsModel> ToDocumentsModel(this List<Document> entitiList)
        {
            List<DocumentsModel> modelList = new List<DocumentsModel>();
            foreach (var entity in entitiList)
            {
                modelList.Add(entity.ToDocModel());
            }
            modelList.TrimExcess();
            return modelList;
        }
        public static Document toEntity(this DocumentsModel model)
        {
            Document entity = new Document { Id = model.Id, StuRollNo = model.StudentRollno, Imageupload = model.Imageupload, Board = model.Board, PassingYear = model.PassingYear, Subjects = model.Subject, TotalMarks = model.TotalMarks, ObtainMarks = model.ObtainMarks };//QualCategory=model.QualificationCategories 
            return entity;
        }
        public static StudentsModel ToStuModel(this StudentDetail entity)
        {
            StudentsModel model = new StudentsModel
            {
                Id = entity.Id,
                StudentRollNo = entity.StudentRollNo,
                ImgUrl = entity.ImageUrl,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                FatherName = entity.FatherName,
                Email = entity.Email,
                Password = entity.Password,
                Guardian = entity.Guardian,
                CNIC = entity.CNIC,
                DateofBirth = entity.DateofBirth,
                Address = entity.Address,
                CellNo = entity.CellNo,
                MobileNo = entity.MobileNo,
                // city = entity.city,
                // subCategory = entity.subCategory,
                // religion = entity.religion,
                // gender = entity.gender
            };
            return model;
        }
        public static List<StudentsModel> ToStudentModel(this List<StudentDetail> entitieslist)
        {
            List<StudentsModel> modelList = new List<StudentsModel>();
            foreach (var entity in entitieslist)
            {
                modelList.Add(entity.ToStuModel());
            }
            modelList.TrimExcess();
            return modelList;
        }
        public static StudentDetail toStuEntity(this StudentsModel model)
        {
            StudentDetail entity = new StudentDetail
            {
                Id = model.Id,
                StudentRollNo = model.StudentRollNo,
                ImageUrl = model.ImgUrl,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FatherName = model.FatherName,
                Email = model.Email,
                Password = model.Password,
                Guardian = model.Guardian,
                CNIC = model.CNIC,
                DateofBirth = model.DateofBirth,
                Address = model.Address,
                CellNo = model.CellNo,
                MobileNo = model.MobileNo
            };//QualCategory=model.QualificationCategories 
            return entity;
        }

    }
}