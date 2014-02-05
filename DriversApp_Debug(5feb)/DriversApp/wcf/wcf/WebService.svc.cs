using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.DataModels;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 
namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WebService.svc or WebService.svc.cs at the Solution Explorer and start debugging.
    public class WebService : IWebService
    {
        public AccountDataClasses1DataContext AccountClass { get; set; }
        public AdminClassDataContext AdminClass { get; set; }
        public PuntenPerBaanDataContext CoordClass { get; set; }
        public CyclusClassDataContext CyclusClass { get; set; }
        public EventsClassDataContext EventClass { get; set; }
        public EventsOpvolgingClassDataContext EventsOpvolgClass { get; set; }
        public NiveauClassDataContext NiveauClass { get; set; }
        public PloegClassDataContext PloegClass { get; set; }
        public TestbaanClassDataContext TestbaanClass { get; set; }
        public TestchauffeurPerCyclusDataContext TestchauffeurPerCyclusClass { get; set; }
        public TestchauffeurClassDataContext TestChauffeurClass { get; set; }
        public TestprocedureClassDataContext TestProcedureClass { get; set; }
        public TestwagenClassDataContext TestWagenClass { get; set; }
       
        public CyclusbladenPerVariantClassDataContext CPVClass { get; set; }
        public EventsPerCyclusbladClassDataContext EPCyclusbladClass { get; set; }
        public ProcedurePerWagenClassDataContext ProcPerWagenClass { get; set; }
        public VariantenClassDataContext VariantenClass { get; set; }
        public TemplatesClassDataContext TemplateClass { get; set; }
        public VersieClassDataContext VersieClass { get; set; }
        public WebService()
        {
            AccountClass = new AccountDataClasses1DataContext();
            AdminClass = new AdminClassDataContext();
            CoordClass = new PuntenPerBaanDataContext();
            CyclusClass = new CyclusClassDataContext();
            EventClass = new EventsClassDataContext();
            EventsOpvolgClass = new EventsOpvolgingClassDataContext();
            NiveauClass = new NiveauClassDataContext();
            PloegClass = new PloegClassDataContext();
            TestbaanClass = new TestbaanClassDataContext();
            TestchauffeurPerCyclusClass = new TestchauffeurPerCyclusDataContext();
            TestChauffeurClass = new TestchauffeurClassDataContext();
            TestProcedureClass = new TestprocedureClassDataContext();
            TestWagenClass = new TestwagenClassDataContext();
            CPVClass = new CyclusbladenPerVariantClassDataContext();
            EPCyclusbladClass = new EventsPerCyclusbladClassDataContext();
            ProcPerWagenClass = new ProcedurePerWagenClassDataContext();
            VariantenClass = new VariantenClassDataContext();
            TemplateClass = new TemplatesClassDataContext();
            VersieClass = new VersieClassDataContext();
        }
        public List<Account> GetAllAccounts()
        {
            return AccountClass.Accounts.ToList();
        }
        public List<Administrator> GetAllAdmins()
        {
            return AdminClass.Administrators.ToList();
        }
       
        public List<PuntenPerBaan> GetAllCoordinaten()
        {
            return CoordClass.PuntenPerBaans.ToList();
        }
        
        public List<Cyclus> GetAllCyclus()
        {
            return CyclusClass.Cyclus.ToList();
        }
        public List<Event> GetAllEvents()
        {
            return EventClass.Events.ToList();
        }
        public List<EventsOpvolging> GetAllEventsOpvolging()
        {
            return EventsOpvolgClass.EventsOpvolgings.ToList();
        }
        public List<Niveaus> GetAllNiveaus()
        {
            return NiveauClass.Niveaus.ToList();
        }
        public List<Ploegen> GetAllPloegen()
        {
            return PloegClass.Ploegens.ToList();
        }
        public List<Testbaan> GetAllTestbanen()
        {
            return TestbaanClass.Testbaans.ToList();
        }
        public List<TestchauffeurPerCyclus> GetAllTestchauffeurPerCyclus()
        {
            return TestchauffeurPerCyclusClass.TestchauffeurPerCyclus.ToList();
        }
        public List<TestChauffeur> GetAllTestChauffeurs()
        {
            return TestChauffeurClass.TestChauffeurs.ToList();
        } 
        public List<TestProcedure> GetAllTestProcedures()
        {
            return TestProcedureClass.TestProcedures.ToList();
        }
        public List<Testwagen> GetAllTestWagens()
        {
            return TestWagenClass.Testwagens.ToList();
        }
        
        public List<CyclusbladenPerVariant> GetAllCyclusbladenPerVariant()
        {
            return CPVClass.CyclusbladenPerVariants.ToList();
        }
        public List<EventsPerCyclusblad> GetAllEventsPerCyclusblad()
        {
            return EPCyclusbladClass.EventsPerCyclusblads.ToList();
        }
        public List<ProceduresPerWagen> GetAllProceduresPerWagen()
        {
            return ProcPerWagenClass.ProceduresPerWagens.ToList();
        }
        public List<Varianten> GetAllVarianten()
        {
            return VariantenClass.Variantens.ToList();
        }
        public List<Template> GetAllTemplates()
        {
            return TemplateClass.Templates.ToList();
        }
        public List<Versie> GetAllVersies()
        {
            return VersieClass.Versies.ToList();
        }
        //Insert, delete commands
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LPG_DEVConnectionString"].ConnectionString);
        public string InsertEventStatus(EventStatus eventstatus)
        {
            string status;
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insert into TabelNaamHere(procedureCode, cyclusbladCode, eventnaam, voltooid) values(@procCode,@cyclCode,@eventnaam,@voltooid)", con);
            //cmd.Parameters.AddWithValue("@procCode", eventstatus.ProcCode);
            
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                status = eventstatus.EventNaam + " wordt in de volgende cyclus toegevoegd";
            }
            else
            {
                status = "Event werd niet toegevoegd";
            }
            con.Close();
            return status;
        }
        public string UpdateVoltooid(EventStatus evnt)
        {
            string status;
            if(con.State==ConnectionState.Closed){
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("update EventsOpvolging set Cel1=@Cel1, Cel2=@Cel2, Cel3=@Cel3, Cel4=@Cel4, Cel5=@Cel5, Cel6=@Cel6, Cel7=@Cel7, Cel8=@Cel8, Cel9=@Cel9, Cel10@Cel10,Cel11=@Cel11, Cel12=@Cel12, Cel13=@Cel13, Cel14=@Cel14, Cel15=@Cel15, Cel16=@Cel16, Cel17=@Cel17, Cel18=@Cel18, Cel19=@Cel19, Cel20=@Cel20, Cel21=@Cel21, Cel22=@Cel22, Cel23=@Cel23, Cel24=@Cel24, Cel25=@Cel25 where");
       cmd.Parameters.AddWithValue("@Cel1", evnt.Cel1);
       cmd.Parameters.AddWithValue("@Cel2", evnt.Cel2);
       cmd.Parameters.AddWithValue("@Cel3", evnt.Cel3);
       cmd.Parameters.AddWithValue("@Cel4", evnt.Cel4);
       cmd.Parameters.AddWithValue("@Cel5", evnt.Cel5);
       cmd.Parameters.AddWithValue("@Cel6", evnt.Cel6);
       cmd.Parameters.AddWithValue("@Cel7", evnt.Cel7);
       cmd.Parameters.AddWithValue("@Cel8", evnt.Cel8);
       cmd.Parameters.AddWithValue("@Cel9", evnt.Cel9);
       cmd.Parameters.AddWithValue("@Cel10", evnt.Cel10);
       cmd.Parameters.AddWithValue("@Cel11", evnt.Cel11);
       cmd.Parameters.AddWithValue("@Cel12", evnt.Cel12);
       cmd.Parameters.AddWithValue("@Cel13", evnt.Cel13);
       cmd.Parameters.AddWithValue("@Cel14", evnt.Cel14);
       cmd.Parameters.AddWithValue("@Cel15", evnt.Cel15);
       cmd.Parameters.AddWithValue("@Cel16", evnt.Cel16);
       cmd.Parameters.AddWithValue("@Cel17", evnt.Cel17);
       cmd.Parameters.AddWithValue("@Cel18", evnt.Cel18);
       cmd.Parameters.AddWithValue("@Cel19", evnt.Cel19);
       cmd.Parameters.AddWithValue("@Cel20", evnt.Cel20);
       cmd.Parameters.AddWithValue("@Cel21", evnt.Cel21);
       cmd.Parameters.AddWithValue("@Cel22", evnt.Cel22);
       cmd.Parameters.AddWithValue("@Cel23", evnt.Cel23);
       cmd.Parameters.AddWithValue("@Cel24", evnt.Cel24);
       cmd.Parameters.AddWithValue("@Cel25", evnt.Cel25);

       int result = cmd.ExecuteNonQuery();
       if (result == 1)
       {
           status = "Gelukt";
       }
       else
       {
           status = "niet gelukt";
       }
       con.Close();
       return status;
        }
    }
}
