
using TemplateEngine.Docx;


namespace Work
{
    public class Report
    {
        public void createreportsVL(System.Collections.Generic.List<string> names)
        {
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

        }
        public void createreportsTest(System.Collections.Generic.List<string> names)
        {
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


        }
    }
}
