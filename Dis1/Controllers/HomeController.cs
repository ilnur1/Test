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

        [Authorize]
        public IActionResult Index()
        {
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            var query = from Report in db.Report
                        where Report.Cc == id
                        where Report.ReportStatus == "1"
                        select Report.Cr;
            int count = 0;
            foreach (var item in query)
            {
                count++;
            }
            ViewBag.Tittle = User.Identity.Name;
            if (count!=0)
            { 
            ViewData["reports"] ="Количество входящих отчетов "+count.ToString();
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

            // Извлечь отправленные данные из Request.Form 

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
            db.Report.Add(new Report { ReportCustomer = names[3], ReportDate = DateTime.Now, ReportStatus = "0", ReportWay = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx", Cc = id1,ReportName=names[0] });
            await db.SaveChangesAsync();
            string Reportwaycmp = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx";
            return RedirectToAction("SendRep");
        }
        [HttpPost]
        public async Task<IActionResult> Work2(List<string> names)
        {

            // Извлечь отправленные данные из Request.Form 


            System.IO.File.Delete("C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0]+ ".docx");
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
            decimal id1 = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id1 = myphone.Cc;
            db.Report.Add(new Report { ReportCustomer = names[3], ReportDate = DateTime.Now, ReportStatus = "0", ReportWay = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx", Cc = id1,ReportName=names[0] });
            await db.SaveChangesAsync();
            string Reportwaycmp = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx";
            return RedirectToAction("SendRep");
        }


        public async Task<IActionResult> Template()
        {

            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            var query = from Shablon in db.Shablon
                        where Shablon.Cc == id
                        select Shablon;

            return View(query.ToList());
        }
        [Authorize]
        public async Task<IActionResult> Personal()
        {

            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            if (id != null)
            {
                Company cmp = await db.Company.FirstOrDefaultAsync(p => p.Cc == id);
                if (cmp != null)
                    return View(cmp);
            }
            return NotFound();
        }

        public async Task<IActionResult> Reports()
        {
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            var query = from Report in db.Report
                        where Report.Cc == id
                        select Report;

            return View(query.ToList());
        }
        public async Task<IActionResult> CompanyCard(decimal id)
        {
            var query = from Company in db.Company
                        where Company.Cc == id
                        select Company;

            
            return View(query.ToList());
          
        }
        [HttpPost]
        public async Task<IActionResult> Input_shablon(Shablon cmp)
        {

            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            db.Shablon.Add(new Shablon { ShablonName = cmp.ShablonName, ShablonPosition = cmp.ShablonPosition, Cc = id, ShablonAgent = cmp.ShablonAgent, ShablonOrder = cmp.ShablonOrder, });
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
        public async Task<IActionResult> Send_email(decimal id)
        {

            var query = from Report in db.Report
                        where Report.Cr == id
                        select Report.ReportWay;
            
            MailAddress from = new MailAddress("19capral95@gmail.com", "Faradey");
            // кому отправляем
            MailAddress to = new MailAddress("zamain88@yandex.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            m.Attachments.Add(new Attachment(query.FirstOrDefault()));
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("19capral95@gmail.com", "");
            smtp.EnableSsl = true;
            smtp.Send(m);

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Send_email_cr(string name)
        {
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            var query1 = from Report in db.Report
                         where Report.Cc == id
                         select Report.ReportWay;
            Reportwaycmp = query1.LastOrDefault();
            MailAddress from = new MailAddress("19capral95@gmail.com", "Faradey");
            // кому отправляем
            MailAddress to = new MailAddress(name);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            m.Attachments.Add(new Attachment(Reportwaycmp));
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("19capral95@gmail.com", "19casper95");
            smtp.EnableSsl = true;
            smtp.Send(m);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Sendcmp(decimal id1)
        {
            var query1 = from Report in db.Report
                        where Report.Cr== id1
                        select Report.ReportWay;
            Reportwaycmp = query1.FirstOrDefault();
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            var query = from Friends in db.Friends
                        from Company in db.Company
                        where Friends.FriendOne == Company.Cc && Friends.FriendTwo == id && Friends.Stat == 1
                        select Company;
            return View(query.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Send_cmp(decimal id)
        {
            decimal id1 = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id1 = myphone.Cc;
            var query1 = from Report in db.Report
                         where Report.Cc == id1
                         select Report.ReportWay;
            Reportwaycmp = query1.LastOrDefault();
            var reportname = from Report in db.Report
                         where Report.Cc == id1
                         select Report.ReportName;
            string Reportname = reportname.LastOrDefault();
         //   decimal id = 0;
         //   Company myphone1 = db.Company.FirstOrDefault(p => p.CompanyLogin == name);
        //    if (myphone1 != null)
         //       id = myphone.Cc;
            db.Report.Add(new Report { ReportCustomer=User.Identity.Name,ReportDate=DateTime.Now,ReportStatus="0",ReportWay=Reportwaycmp, Cc= id,ReportName=Reportname });
            await db.SaveChangesAsync();
            Reportwaycmp = "";
            return RedirectToAction("Index");
            

        }

        public IActionResult WorkSh()
        {

            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            var query = from Shablon in db.Shablon
                        where Shablon.Cc == id
                        select Shablon;
            return View(query.ToList());
        }
        [HttpPost] //не используй больше названия типа work1, work2 итп
        public async Task<IActionResult> Work(decimal build, decimal project, decimal customer, decimal genbuild)
        {
            //переименуй элемени=ты на норм названия
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            var query = from Shablon in db.Shablon where Shablon.Cc == id && Shablon.Cs==build select Shablon.ShablonAgent;
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

            //тут тоже названия запроса норм сделай
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
            id = myphone.Cc;
            var query = from Friends in db.Friends
                        from Company in db.Company
                        where Friends.FriendOne == Company.Cc && Friends.FriendTwo == id && Friends.Stat == 1
                        select Company;

            return View(query.ToList());

        }
        public IActionResult Company_All()
        {
            return View(db.Company.ToList());
        }
        public IActionResult Company_Req()
        {
            decimal id = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id = myphone.Cc;
            //и тут
            var query = from Friends in db.Friends
                        from Company in db.Company
                        where Friends.FriendOne == id && Friends.FriendTwo == Company.Cc && Friends.Stat == 0
                        select Company;

            return View(query.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> Company_Add(decimal id)
        {

            decimal id1 = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id1 = myphone.Cc;
            db.Friends.Add(new Friends { FriendOne=id1,FriendTwo=id,Stat=0 });
            await db.SaveChangesAsync();
            return RedirectToAction("Company_Req");
        }

        [HttpPost]
        public async Task<IActionResult> Company_Add_Friend(decimal id)
        {

            decimal id1 = 0;
            Company myphone = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (myphone != null)
                id1 = myphone.Cc;
            db.Friends.Update(new Friends{ FriendOne=id1,FriendTwo=id,Stat=1});
            db.Friends.Update(new Friends { FriendOne = id, FriendTwo = id1, Stat = 1 });
            await db.SaveChangesAsync();
            return RedirectToAction("Company_All");
        }


        
        public async Task<IActionResult> SendRep()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
