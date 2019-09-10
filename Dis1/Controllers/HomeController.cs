using System;
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
        string Reportwaycmp = "";
        private Fara1Context db;
        public HomeController(Fara1Context context)
        {
            db = context;
        }

        public decimal Getid()
        {
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            return id;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {/*
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
                */
         /*
     var query = from Report in db.Report
                 where Report.Cc == Getid()// сделал типо вызов метода что бы получать id
                 where Report.ReportStatus == "1"
                 select Report.Cr; */
            var idreport = db.Report.Where(c => c.Cc == Getid()).Where(c => c.ReportStatus == "1").Select(c => c.Cr);// переделал на контекст
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
            /*
            decimal id1 = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id1 = myphone.Cc;*/
            db.Report.Add(new Report { ReportCustomer = names[3], ReportDate = DateTime.Now, ReportStatus = "0", ReportWay = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx", Cc = Getid(), ReportName = names[0] });// сделал типо вызов метода что бы получать id
            await db.SaveChangesAsync();
            string Reportwaycmp = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx";
            return RedirectToAction("SendRep");
        }


        public async Task<IActionResult> Template()
        {
            /*
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;*/
            /*
        var query = from Shablon in db.Shablon
                    where Shablon.Cc == Getid()// сделал типо вызов метода что бы получать id
                    select Shablon;
                    */
            var ShablonTL = db.Shablon.Where(c => c.Cc == Getid()).Select(c => c);// переделал на контекст

            return View(ShablonTL.ToList());
        }
        [Authorize]
        public async Task<IActionResult> Personal()
        {
            /*
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;*/
            if (Getid() != null)
            {
                Company cmp = await db.Company.FirstOrDefaultAsync(p => p.Cc == Getid());// сделал типо вызов метода что бы получать id
                if (cmp != null)
                    return View(cmp);
            }
            return NotFound();
        }

        public async Task<IActionResult> Reports()
        {/*
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;*/
            var query = from Report in db.Report
                        where Report.Cc == Getid()// сделал типо вызов метода что бы получать id
                        select Report;
            var ReportVL = db.Report.Where(c => c.Cc == Getid()).Select(c => c);// переделал на контекст

            return View(ReportVL.ToList());
        }
        public async Task<IActionResult> CompanyCard(decimal id)
        {
            /*
            var query = from Company in db.Company
                        where Company.Cc == id
                        select Company;
                        */

            var CompanyTL = db.Company.Where(c => c.Cc == Getid()).Select(c => c);// переделал на контекст
            return View(CompanyTL.ToList());

        }
        public async Task<IActionResult> TemplateLook(decimal id)
        {
           
            var TemplateTL = db.Shablon.Where(c => c.Cc == id).Select(c => c);// переделал на контекст
            return View(TemplateTL.ToList());

        }
        [HttpPost]
        public async Task<IActionResult> Input_shablon(Shablon cmp)
        {
            /*
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;*/

            // добавить, добавление шаблона после изменения бд
            db.Shablon.Add(new Shablon { ShablonName = cmp.ShablonName, ShablonPosition = cmp.ShablonPosition, Cc = Getid(), ShablonAgent = cmp.ShablonAgent, ShablonOrder = cmp.ShablonOrder, });// сделал типо вызов метода что бы получать id
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

            Shablon Cod = db.Shablon.FirstOrDefault(p => p.Cs == id);
            db.Shablon.Remove(Cod);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete1(decimal id)
        {

            Report Cod1 = db.Report.FirstOrDefault(p => p.Cr == id);
            db.Report.Remove(Cod1);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Send_email(decimal id)// Можно наверное сделать метод для отправки по почти с входным параметром для отправки почты на свой ящик или на почту указанную
        {
            /*
            var query = from Report in db.Report
                        where Report.Cr == id
                        select Report.ReportWay;
                        */
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
        public async Task<IActionResult> Send_email_cr(string name)
        {
            /*
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;*/
            /*
            var query1 = from Report in db.Report
                         where Report.Cc == Getid()
                         select Report.ReportWay;
                         */
            var RepWay = db.Report.Where(c => c.Cc == Getid()).Select(c => c.ReportWay);// переделал на контекст
            Reportwaycmp = RepWay.LastOrDefault();
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
            mail.Attachments.Add(new Attachment(Reportwaycmp));
            mail.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("19capral95@gmail.com", "19casper95");
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Sendcmp(decimal id1)
        {
            /*
            var query1 = from Report in db.Report
                        where Report.Cr== id1
                        select Report.ReportWay;
                        */
            var RepWay = db.Report.Where(c => c.Cr == id1).Select(c => c.ReportWay);// переделал на контекст
            Reportwaycmp = RepWay.FirstOrDefault();
            /*
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;*/
            /*
        var query = from Friends in db.Friends
                    from Company in db.Company
                    where Friends.FriendOne == Company.Cc && Friends.FriendTwo == Getid() && Friends.Stat == 1// сделал типо вызов метода что бы получать id
                    select Company;
                    */
            var CompanyTL = from p in db.Friends join c in db.Company on p.FriendOne equals c.Cc where p.FriendTwo == Getid() && p.Stat == 1 select c;// хз работает или нет
            return View(CompanyTL.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Send_cmp(decimal id)
        {
            /*
            decimal id1 = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id1 = myphone.Cc;*/
            /*
        var query1 = from Report in db.Report
                     where Report.Cc == Getid()// сделал типо вызов метода что бы получать id
                     select Report.ReportWay; */
            var RepWay = db.Report.Where(c => c.Cc == Getid()).Select(c => c.ReportWay);// переделал на контекст
            Reportwaycmp = RepWay.LastOrDefault();
            var RepName = db.Report.Where(c => c.Cc == Getid()).Select(c => c.ReportName);
            /*
            var reportname = from Report in db.Report
                         where Report.Cc == Getid()// сделал типо вызов метода что бы получать id
                             select Report.ReportName;
                             */
            string Reportname = RepName.LastOrDefault();
            //   decimal id = 0;
            //   Company myphone1 = db.Company.FirstOrDefault(p => p.CompanyLogin == name);
            //    if (myphone1 != null)
            //       id = myphone.Cc;
            db.Report.Add(new Report { ReportCustomer = User.Identity.Name, ReportDate = DateTime.Now, ReportStatus = "0", ReportWay = Reportwaycmp, Cc = id, ReportName = Reportname });
            await db.SaveChangesAsync();
            Reportwaycmp = "";
            return RedirectToAction("Index");


        }

        public IActionResult WorkSh()
        {
            /*
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;*/
                /*
            var query = from Shablon in db.Shablon
                        where Shablon.Cc == Getid()// сделал типо вызов метода что бы получать id
                        select Shablon;*/
            var ShablonTL = db.Shablon.Where(c => c.Cc == Getid()).Select(c => c);
            return View(ShablonTL.ToList());
        }
        [HttpPost] //не используй больше названия типа work1, work2 итп
        public async Task<IActionResult> Work(decimal build, decimal project, decimal customer, decimal genbuild)
        {
            //переименуй элемени=ты на норм названия (А) мне кажется мы тут все переделаем, так что, отложим
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            var query = from Shablon in db.Shablon where Shablon.Cc == id && Shablon.Cs == build select Shablon.ShablonAgent;
            var query1 = from Shablon in db.Shablon where Shablon.Cc == id && Shablon.Cs == build select Shablon.ShablonName;
            var query2 = from Shablon in db.Shablon where Shablon.Cc == id && Shablon.Cs == build select Shablon.ShablonOrder;
            var query3 = from Shablon in db.Shablon where Shablon.Cc == id && Shablon.Cs == build select Shablon.ShablonPosition;
            string q = query.FirstOrDefault();
            string q1 = query1.FirstOrDefault();
            string q2 = query2.FirstOrDefault();
            string q3 = query3.FirstOrDefault();
            ViewData["buid"] = q;
            ViewData["buid1"] = q1;
            ViewData["buid2"] = q2;
            ViewData["buid3"] = q3;
            return View();
        }
        public IActionResult AddSh()
        {
            return View();
        }
        [Authorize]
        public IActionResult Company()
        {

            //тут тоже названия запроса норм сделай (А)
            /* decimal id = 0; 
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
            id = myphone.Cc;*/
            /*
            var query = from Friends in db.Friends
                        from Company in db.Company
                        where Friends.FriendOne == Company.Cc && Friends.FriendTwo == Getid() && Friends.Stat == 1// сделал типо вызов метода что бы получать id
                        select Company;
                        */
            var CompanyTL = from p in db.Friends join c in db.Company on p.FriendOne equals c.Cc where p.FriendTwo == Getid() && p.Stat == 1 select c;
            return View(CompanyTL.ToList());

        }
        public IActionResult Company_All()
        {
            
            return View(db.Company.ToList());
        }
        public IActionResult Company_Req()
        {
            /*
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;*/
            //и тут
            /*
            var query = from Friends in db.Friends
                        from Company in db.Company
                        where Friends.FriendOne == Getid() && Friends.FriendTwo == Company.Cc && Friends.Stat == 0// сделал типо вызов метода что бы получать id
                        select Company;
                        */
            var CompanyTL = from p in db.Friends join c in db.Company on p.FriendOne equals Getid() where p.FriendTwo == c.Cc && p.Stat == 0 select c;// хз работает или нет
            return View(CompanyTL.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> Company_Add(decimal id)
        {
            
            /*
            decimal id1 = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id1 = myphone.Cc;*/
            
            var friend1 = db.Friends.Where(c => c.FriendOne == Getid()).Where(c => c.FriendTwo == id).Where(c=>c.Stat==1).FirstOrDefault();
            var friend2 = db.Friends.Where(c => c.FriendOne == Getid()).Where(c => c.FriendTwo == id).Where(c => c.Stat == 0).FirstOrDefault();
            if (friend1 == null && friend2 == null)
            {
                db.Friends.Add(new Friends { FriendOne = Getid(), FriendTwo = id, Stat = 0 });// сделал типо вызов метода что бы получать id
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
            /*
            decimal id1 = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id1 = myphone.Cc;*/
            var friend = db.Friends.Where(c => c.FriendOne == Getid()).Where(c => c.FriendTwo == id).FirstOrDefault();
            friend.Stat = 1;
           // db.Friends.Update(new Friends { FriendOne = Getid(), FriendTwo = id, Stat = 1 });// сделал типо вызов метода что бы получать id
            db.Friends.Update(new Friends { FriendOne = id, FriendTwo = Getid(), Stat = 1 });// сделал типо вызов метода что бы получать id
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
