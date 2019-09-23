﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dis1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TemplateEngine.Docx;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.IO;

namespace Dis1.Controllers
{
    public class HomeController : Controller
    {
        string reportwaycmp = "";
        private Fara1Context db;
        public HomeController(Fara1Context context)
        {
            db = context;
        }

        public decimal Getuserid()
        {
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            return id;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var idreport = db.Report.Where(c => c.Cc == Getuserid()).Where(c => c.ReportStatus == "1").Select(c => c.Cr);// переделал на контекст
            int count = 0;
            foreach (var item in idreport)
            {
                count++;
            }
            ViewBag.Tittle = User.Identity.Name;
            if (count != 0)
            {
                ViewData["reports"] = "Количество входящих отчетов " + count.ToString();
            }
            else
            {
                ViewData["reports"] = "Входящие отчеты отсутствуют";
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Work1(List<string> names)
        {

            // Извлечь отправленные данные из Request.Form (А) не понял

            System.IO.File.Delete("C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx");
            //   System.IO.File.Delete("C:\\Users\\aynur\\Downloads\\Reportdoc2.docx");
            System.IO.File.Copy("C:\\Users\\aynur\\Downloads\\Reportdoc.docx", "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx");

            var valuesToFill = new TemplateEngine.Docx.Content(
                new FieldContent("ObjectName", names[1]),
                new FieldContent("drawing", names[2]),
                new FieldContent("data", names[3]),
                new FieldContent("CustomerName", names[4]),
                new FieldContent("CustomerNamePos", names[5]),
                new FieldContent("CustomerCompany", names[6]),
                new FieldContent("CustomerReq", names[7]),
                new FieldContent("ConractorName", names[8]),
                new FieldContent("ConractorNamePos", names[9]),
                new FieldContent("ConractorReq", names[10]),
                new FieldContent("ConractorCompany", names[11]),
                new FieldContent("ProjectName", names[12]),
                new FieldContent("ProjectReq", names[13]),
                new FieldContent("Prname", names[14]),
                new FieldContent("PrnamePos", names[15]),
                //   new FieldContent("BuildControlCmp", names[16]),
                new FieldContent("BuildControlPos", names[16]),
                new FieldContent("BuildControlName", names[17]),
                //   new FieldContent("BuildControlReq", names[19]),
                //    new FieldContent("EquipmentCompany", names[20]),
                //   new FieldContent("equipmentprovider", names[21]),
                new FieldContent("work", names[18]),
                new FieldContent("elinstall", names[19]),
                new FieldContent("trials", names[20]),
                new FieldContent("GenCustomerName", names[21]),
                new FieldContent("GenCustomerNamePos", names[22]),
                new FieldContent("GenCustomerCompany", names[23]),
                new FieldContent("num", names[24]),
                new FieldContent("datehidwork", names[25]),
                new FieldContent("hidework", names[26]),
                new FieldContent("material", names[27]),
                new FieldContent("date1", names[28]),
                new FieldContent("date2", names[29]),
                new FieldContent("datedraw", names[30]),
                new FieldContent("izarea", names[31]),
                new FieldContent("iztype", names[32]),
                new FieldContent("izcount", names[33]),
                new FieldContent("wire", names[34]),
                new FieldContent("wirecount", names[35]),
                new FieldContent("intermediate", names[36]),
                new FieldContent("anker", names[37]),
                new FieldContent("corn", names[38]),
                new FieldContent("other", names[39]));


            using (var outputDocument = new TemplateProcessor("C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx")
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();

            }
            decimal id1 = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id1 = myphone.Cc;
            db.Report.Add(new Report { ReportCustomer = names[3], ReportDate = DateTime.Now, ReportStatus = "0", ReportWay = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx", Cc = id1, ReportName = names[0] });
            await db.SaveChangesAsync();
            string Reportwaycmp = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx";
            return RedirectToAction("SendRep");
        }
        [HttpPost]
        public async Task<IActionResult> Work2(List<string> names)
        {

            // Извлечь отправленные данные из Request.Form (А) не понял


            System.IO.File.Delete("C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx");
            System.IO.File.Copy("C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\test.docx", "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx");

            var valuesToFill = new TemplateEngine.Docx.Content(
                new FieldContent("Objectname", names[1]),
                new FieldContent("drawing", names[2]),
                new FieldContent("data", names[3]),
                new FieldContent("CustomerCompany", names[4]),
                new FieldContent("CustomerNamePos", names[5]),
                new FieldContent("ConractorCompany", names[6]),
                new FieldContent("ConractorName", names[7]),
                new FieldContent("GenCustomerName", names[8]),
                new FieldContent("Work", names[9]),
                new FieldContent("ProjectName", names[10]));


            using (var outputDocument = new TemplateProcessor("C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx")
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();

            }
           
            db.Report.Add(new Report { ReportCustomer = names[3], ReportDate = DateTime.Now, ReportStatus = "0", ReportWay = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx", Cc = Getuserid(), ReportName = names[0] });// сделал типо вызов метода что бы получать id
            await db.SaveChangesAsync();
            string Reportwaycmp = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx";
            return RedirectToAction("SendRep");
        }


        public async Task<IActionResult> Template()
        {
           
            var ShablonTL = db.Shablon.Where(c => c.Cc == Getuserid()).Select(c => c);// переделал на контекст

            return View(ShablonTL.ToList());
        }
        [Authorize]
        public async Task<IActionResult> Personal()
        {
            
            if (Getuserid() != null)
            {
                Company cmp = await db.Company.FirstOrDefaultAsync(p => p.Cc == Getuserid());// сделал типо вызов метода что бы получать id
                if (cmp != null)
                    return View(cmp);
            }
            return NotFound();
        }

        public async Task<IActionResult> Reports()
        {

            var userreport = db.Report.Where(c => c.Cc == Getuserid()).Select(c => c);// переделал на контекст

            return View(userreport.ToList());
        }
        public async Task<IActionResult> CompanyCard(decimal id)
        {
            

            var companycard = db.Company.Where(c => c.Cc == Getuserid()).Select(c => c);// переделал на контекст
            return View(companycard.ToList());

        }
        public async Task<IActionResult> TemplateLook(decimal id)
        {
           
            var usertemplate = db.Shablon.Where(c => c.Cc == id).Select(c => c);// переделал на контекст
            return View(usertemplate.ToList());

        }
        [HttpPost]
        public async Task<IActionResult> Input_shablon(Shablon cmp)
        {
       
            // добавить, добавление шаблона после изменения бд
            db.Shablon.Add(new Shablon { ShablonName = cmp.ShablonName, ShablonPosition = cmp.ShablonPosition, Cc = Getuserid(), ShablonAgent = cmp.ShablonAgent, ShablonOrder = cmp.ShablonOrder, });// сделал типо вызов метода что бы получать id
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Input(Company cmp)
        {

            db.Company.Add(cmp);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Company cmp)
        {

            db.Company.Update(cmp);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(decimal id)
        {

            Shablon deleteshablonid = db.Shablon.FirstOrDefault(p => p.Cs == id);
            db.Shablon.Remove(deleteshablonid);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete1(decimal id)
        {

            Report deletereportid = db.Report.FirstOrDefault(p => p.Cr == id);
            db.Report.Remove(deletereportid);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Send_email(decimal id)// Можно наверное сделать метод для отправки по почти с входным параметром для отправки почты на свой ящик или на почту указанную
        {
   
            var RepWay = db.Report.Where(c => c.Cr == id).Select(c => c.ReportWay);// переделал на контекст

            MailAddress from = new MailAddress("19capral95@gmail.com", "Faradey");
            // кому отправляем
            MailAddress to = new MailAddress("zamain88@yandex.ru");
            // создаем объект сообщения
            MailMessage mail = new MailMessage(from, to);
            // тема письма
            mail.Subject = "Тест";
            // текст письма
            mail.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            mail.Attachments.Add(new Attachment(RepWay.FirstOrDefault()));
            mail.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("19capral95@gmail.com", "");
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return RedirectToAction("Index");

        }

        /// <summary>
        /// Отправка письма
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mailAddres">адрес получателя</param>
        /// <returns></returns>
        public async Task<IActionResult> Send_email(decimal id, string mailAddres, string headMessange, string bodyMessange)
        {
            var RepWay = db.Report.Where(c => c.Cr == id).Select(c => c.ReportWay);// переделал на контекст

            MailAddress from = new MailAddress("19capral95@gmail.com", "Faradey");
            // кому отправляем
            MailAddress to = new MailAddress(mailAddres);
            // создаем объект сообщения
            MailMessage mail = new MailMessage(from, to);

            FillinMail(mail, headMessange, bodyMessange);

            // письмо представляет код html
            mail.Attachments.Add(new Attachment(RepWay.FirstOrDefault()));
            mail.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("19capral95@gmail.com", "");
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return RedirectToAction("Index");
        }

        private void FillinMail(MailMessage mail, string headMessange, string bodyMessange)
        {
            mail.Subject = headMessange;
            // текст письма
            mail.Body = $"<h2>{bodyMessange}</h2>";
        }

        public async Task<IActionResult> Send_email_cr(string name)
        {
          
            var RepWay = db.Report.Where(c => c.Cc == Getuserid()).Select(c => c.ReportWay);// переделал на контекст
            reportwaycmp = RepWay.LastOrDefault();
            MailAddress from = new MailAddress("19capral95@gmail.com", "Faradey");
            // кому отправляем
            MailAddress to = new MailAddress(name);
            // создаем объект сообщения
            MailMessage mail = new MailMessage(from, to);
            // тема письма
            mail.Subject = "Тест";
            // текст письма
            mail.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            mail.Attachments.Add(new Attachment(reportwaycmp));
            mail.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("19capral95@gmail.com", "19casper95");
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Send_email_cr(string mailAddres, string headMessange, string bodyMessange)
        {
            var RepWay = db.Report.Where(c => c.Cc == Getuserid()).Select(c => c.ReportWay);// переделал на контекст
            reportwaycmp = RepWay.LastOrDefault();
            MailAddress from = new MailAddress("19capral95@gmail.com", "Faradey");
            // кому отправляем
            MailAddress to = new MailAddress(mailAddres);
            // создаем объект сообщения
            MailMessage mail = new MailMessage(from, to);

            FillinMail(mail, headMessange, bodyMessange);

            mail.Attachments.Add(new Attachment(reportwaycmp));
            mail.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять пис+ьмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("19capral95@gmail.com", "19casper95");
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Sendcmp(decimal id1)
        {
           
            var repway = db.Report.Where(c => c.Cr == id1).Select(c => c.ReportWay);// переделал на контекст
            reportwaycmp = repway.FirstOrDefault();
            
            var CompanyTL = from p in db.Friends join c in db.Company on p.FriendOne equals c.Cc where p.FriendTwo == Getuserid() && p.Stat == 1 select c;// хз работает или нет
            return View(CompanyTL.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Send_cmp(decimal id)
        {
          
            var reportway = db.Report.Where(c => c.Cc == Getuserid()).Select(c => c.ReportWay);// переделал на контекст
            reportwaycmp = reportway.LastOrDefault();
            var reportname = db.Report.Where(c => c.Cc == Getuserid()).Select(c => c.ReportName);
           
            string Reportname = reportname.LastOrDefault();
           
            db.Report.Add(new Report { ReportCustomer = User.Identity.Name, ReportDate = DateTime.Now, ReportStatus = "0", ReportWay = reportwaycmp, Cc = id, ReportName = Reportname });
            await db.SaveChangesAsync();
            reportwaycmp = "";
            return RedirectToAction("Index");


        }

        public IActionResult WorkSh()
        {
            
            var templateforwork = db.Shablon.Where(c => c.Cc == Getuserid()).Select(c => c);
            return View(templateforwork.ToList());
        }
        [HttpPost] //не используй больше названия типа work1, work2 итп
        public async Task<IActionResult> Work(decimal build, decimal project, decimal customer, decimal genbuild)
        {
            //переименуй элемени=ты на норм названия (А) мне кажется мы тут все переделаем, так что, отложим
            decimal id = 0;
            Company company = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (company == null)
                return View();

            var value = db.Shablon.Where(x => x.Cc == company.Cc).ToList();

            ViewData["buid"] = value.FirstOrDefault().ShablonAgent;
            ViewData["buid1"] = value.FirstOrDefault().ShablonName;
            ViewData["buid2"] = value.FirstOrDefault().ShablonOrder;
            ViewData["buid3"] = value.FirstOrDefault().ShablonPosition;
            return View();
        }
        public IActionResult AddSh()
        {
            return View();
        }
        [Authorize]
        public IActionResult Company()
        {

          
            var allcompany = from p in db.Friends join c in db.Company on p.FriendOne equals c.Cc where p.FriendTwo == Getuserid() && p.Stat == 1 select c;
            return View(allcompany.ToList());

        }
        public IActionResult Company_All()
        {
            
            return View(db.Company.ToList());
        }
        public IActionResult Company_Req()
        {
            
            var friendscompany = from p in db.Friends join c in db.Company on p.FriendOne equals Getuserid() where p.FriendTwo == c.Cc && p.Stat == 0 select c;// хз работает или нет
            return View(friendscompany.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> Company_Add(decimal id)
        {
            
           
            var friend1 = db.Friends.Where(c => c.FriendOne == Getuserid()).Where(c => c.FriendTwo == id).Where(c=>c.Stat==1).FirstOrDefault();
            var friend2 = db.Friends.Where(c => c.FriendOne == Getuserid()).Where(c => c.FriendTwo == id).Where(c => c.Stat == 0).FirstOrDefault();
            if (friend1 == null && friend2 == null)
            {
                db.Friends.Add(new Friends { FriendOne = Getuserid(), FriendTwo = id, Stat = 0 });// сделал типо вызов метода что бы получать id
                await db.SaveChangesAsync();
                return RedirectToAction("Company_Req");
            }
            else
            {
                
                return RedirectToAction("Company_All");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Company_Add_Friend(decimal id)
        {
         
            var friend = db.Friends.Where(c => c.FriendOne == Getuserid()).Where(c => c.FriendTwo == id).FirstOrDefault();
            friend.Stat = 1;

            db.Friends.Update(new Friends { FriendOne = id, FriendTwo = Getuserid(), Stat = 1 });// сделал типо вызов метода что бы получать id
            await db.SaveChangesAsync();
            return RedirectToAction("Company_All");
        }

        public async Task<IActionResult> SendRep()
        {

            return View();
        }
        // метода для скачивания файлов
        public VirtualFileResult GetVirtualFile(decimal id1)
        {
            var reportname = db.Report.Where(c => c.Cr== id1).Select(c => c.ReportName).FirstOrDefault();
            var reportway = db.Report.Where(c => c.Cr == id1).Select(c => c.ReportWay).FirstOrDefault();
            string RN = reportname.TrimEnd(new char[] {' '}) + ".docx";
            string RW = reportway;
            //не получается вставить путь из папки
            var filepath = Path.Combine("~/reports", RN);
            return File(filepath, "text/plain", RN);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
