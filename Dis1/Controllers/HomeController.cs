using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dis1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.IO;
using Dis1.Works;
using Dis1.Filters;



namespace Dis1.Controllers
{
    public class HomeController : Controller
    {
        string reportwaycmp = "";
        private Fara1Context db;
        Createreport createreport = new Createreport();
        Mail sendmail = new Mail();
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
        [CustomExceptionFilter]
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
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> Work1(List<string> names)
        {
            // Извлечь отправленные данные из Request.Form (А) не понял
            createreport.createreportsVL(names);
            db.Report.Add(new Report { ReportCustomer = names[3], ReportDate = DateTime.Now, ReportStatus = "0", ReportWay = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx", Cc = Getuserid(), ReportName = names[0] });
            await db.SaveChangesAsync();
            string Reportwaycmp = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx";
            return RedirectToAction("SendRep");
        }
        [HttpPost]
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> Work2(List<string> names)
        {
            createreport.createreportsTest(names);
            db.Report.Add(new Report { ReportCustomer = names[3], ReportDate = DateTime.Now, ReportStatus = "0", ReportWay = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx", Cc = Getuserid(), ReportName = names[0] });// сделал типо вызов метода что бы получать id
            await db.SaveChangesAsync();
            string Reportwaycmp = "C:\\Users\\aynur\\source\\repos\\Faradey\\Dis1\\wwwroot\\reports\\" + names[0] + ".docx";
            return RedirectToAction("SendRep");
        }
        [CustomExceptionFilter]
        public async Task<IActionResult> Template()
        {
            var ShablonTL = db.Shablon.Where(c => c.Cc == Getuserid()).Select(c => c);// переделал на контекст
            return View(ShablonTL.ToList());
        }
        [Authorize]
        [CustomExceptionFilter]
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
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> Reports()
        {
            var userreport = db.Report.Where(c => c.Cc == Getuserid()).Select(c => c);// переделал на контекст
            return View(userreport.ToList());
        }
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> CompanyCard(decimal id)
        {
            var companycard = db.Company.Where(c => c.Cc == Getuserid()).Select(c => c);// переделал на контекст
            return View(companycard.ToList());
        }
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> TemplateLook(decimal id)
        {
            var usertemplate = db.Shablon.Where(c => c.Cc == id).Select(c => c);// переделал на контекст
            return View(usertemplate.ToList());
        }
        [HttpPost]
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> Input_shablon(Shablon cmp)
        {
            // добавить, добавление шаблона после изменения бд
            db.Shablon.Add(new Shablon { ShablonName = cmp.ShablonName, ShablonPosition = cmp.ShablonPosition, Cc = Getuserid(), ShablonAgent = cmp.ShablonAgent, ShablonOrder = cmp.ShablonOrder, });// сделал типо вызов метода что бы получать id
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> Input(Company cmp)
        {

            db.Company.Add(cmp);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> Edit(Company cmp)
        {
            db.Company.Update(cmp);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> Delete(decimal id)
        {
            Shablon deleteshablonid = db.Shablon.FirstOrDefault(p => p.Cs == id);
            db.Shablon.Remove(deleteshablonid);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> Delete1(decimal id)
        {

            Report deletereportid = db.Report.FirstOrDefault(p => p.Cr == id);
            db.Report.Remove(deletereportid);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize]
        [CustomExceptionFilter]/// <summary>
                               /// Отправка письма
                               /// </summary>
                               /// <param name="id"></param>
                               /// <param name="mailAddres">адрес получателя</param>
                               /// <returns></returns>
        public async Task<IActionResult> Send_email(decimal id)
        {
            var reportwaycmp = db.Report.Where(c => c.Cr == id).Select(c => c.ReportWay).FirstOrDefault();// переделал на контекст
            var ownmailadress = db.Company.Where(c => c.Cc == Getuserid()).Select(c => c.CompanyName).FirstOrDefault();//пока название компании, когда появится строка почтового вдреса изменить
            sendmail.sendmail( reportwaycmp,  ownmailadress);
            return RedirectToAction("Index");
        }

        private void FillinMail(MailMessage mail, string headMessange, string bodyMessange)
        {
            mail.Subject = headMessange;
            // текст письма
            mail.Body = $"<h2>{bodyMessange}</h2>";
        }
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> Send_email_cr(string name)
        {
            var reportwaycmp = db.Report.Where(c => c.Cc == Getuserid()).Select(c => c.ReportWay).LastOrDefault();// переделал на контекст
            sendmail.sendmail(reportwaycmp, name);
            return RedirectToAction("Index");

        }
        
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> Sendcmp(decimal id1)
        {
           
            var reportwaycmp = db.Report.Where(c => c.Cr == id1).Select(c => c.ReportWay).FirstOrDefault();// переделал на контекст
            var CompanyTL = from p in db.Friends join c in db.Company on p.FriendOne equals c.Cc where p.FriendTwo == Getuserid() && p.Stat == 1 select c;// хз работает или нет
            return View(CompanyTL.ToList());
        }

        [HttpPost]
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> Send_cmp(decimal id)
        {
          
            var reportwaycmp = db.Report.Where(c => c.Cc == Getuserid()).Select(c => c.ReportWay).LastOrDefault();// переделал на контекст
            var reportname = db.Report.Where(c => c.Cc == Getuserid()).Select(c => c.ReportName).LastOrDefault();
            db.Report.Add(new Report { ReportCustomer = User.Identity.Name, ReportDate = DateTime.Now, ReportStatus = "0", ReportWay = reportwaycmp, Cc = id, ReportName = reportname });
            await db.SaveChangesAsync();
            reportwaycmp = "";
            return RedirectToAction("Index");


        }
        [Authorize]
        [CustomExceptionFilter]
        public IActionResult WorkSh()
        {
            
            var templateforwork = db.Shablon.Where(c => c.Cc == Getuserid()).Select(c => c);
            return View(templateforwork.ToList());
        }
        [HttpPost]
        [Authorize]
        [CustomExceptionFilter] //не используй больше названия типа work1, work2 итп
        public async Task<IActionResult> Work(decimal build, decimal project, decimal customer, decimal genbuild)
        {
            //переименуй элемени=ты на норм названия (А) мне кажется мы тут все переделаем, так что, отложим
            decimal id = 0;
            Company company = db.Company.FirstOrDefault(p => p.CompanyLogin == User.Identity.Name);
            if (company == null)
                return View();

            var value = db.Shablon.FirstOrDefault(x => x.Cc == company.Cc);

            ViewData["buid"] = value.ShablonAgent;
            ViewData["buid1"] = value.ShablonName;
            ViewData["buid2"] = value.ShablonOrder;
            ViewData["buid3"] = value.ShablonPosition;
            
            return View();
        }
        [Authorize]
        [CustomExceptionFilter]
        public IActionResult AddSh()
        {
            return View();
        }
        [Authorize]
        [CustomExceptionFilter]
        public IActionResult Company()
        {
            var allcompany = from p in db.Friends join c in db.Company on p.FriendOne equals c.Cc where p.FriendTwo == Getuserid() && p.Stat == 1 select c;
            return View(allcompany.ToList());

        }
        [Authorize]
        [CustomExceptionFilter]
        public IActionResult Company_All()
        {
            return View(db.Company.ToList());
        }
        [Authorize]
        [CustomExceptionFilter]
        public IActionResult Company_Req()
        {
            var friendscompany = from p in db.Friends join c in db.Company on p.FriendOne equals Getuserid() where p.FriendTwo == c.Cc && p.Stat == 0 select c;// хз работает или нет
            return View(friendscompany.ToList());
        }
        [HttpPost]
        [Authorize]
        [CustomExceptionFilter]
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
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> Company_Add_Friend(decimal id)
        {
            var friend = db.Friends.Where(c => c.FriendOne == Getuserid()).Where(c => c.FriendTwo == id).FirstOrDefault();
            friend.Stat = 1;
            db.Friends.Update(new Friends { FriendOne = id, FriendTwo = Getuserid(), Stat = 1 });// сделал типо вызов метода что бы получать id
            await db.SaveChangesAsync();
            return RedirectToAction("Company_All");
        }
        [Authorize]
        [CustomExceptionFilter]
        public async Task<IActionResult> SendRep()
        {

            return View();
        }
        // метода для скачивания файлов
        [CustomExceptionFilter]
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
