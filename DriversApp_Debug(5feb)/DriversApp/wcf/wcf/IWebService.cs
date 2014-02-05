using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.DataModels;
using System.Data;
using System.Data.SqlClient;
namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWebService" in both code and config file together.
    [ServiceContract]
    public interface IWebService
    {
        [OperationContract]
        List<Account> GetAllAccounts();
        [OperationContract]
        List<Administrator> GetAllAdmins();
        [OperationContract]
        List<Cyclus> GetAllCyclus();
        [OperationContract]
        List<CyclusbladenPerVariant> GetAllCyclusbladenPerVariant();
        [OperationContract]
        List<Event> GetAllEvents();
        [OperationContract]
        List<EventsOpvolging> GetAllEventsOpvolging();
        [OperationContract]
        List<EventsPerCyclusblad> GetAllEventsPerCyclusblad();
        [OperationContract]
        List<Niveaus> GetAllNiveaus();
        [OperationContract]
        List<Ploegen> GetAllPloegen();
        [OperationContract]
        List<ProceduresPerWagen> GetAllProceduresPerWagen();
        [OperationContract]
        List<PuntenPerBaan> GetAllCoordinaten();
        [OperationContract]
        List<Template> GetAllTemplates();
        [OperationContract]
        List<Testbaan> GetAllTestbanen();
        [OperationContract]
        List<TestchauffeurPerCyclus> GetAllTestchauffeurPerCyclus();
        [OperationContract]
        List<TestChauffeur> GetAllTestChauffeurs();
        [OperationContract]
        List<TestProcedure> GetAllTestProcedures();
        [OperationContract]
        List<Testwagen> GetAllTestWagens();
        [OperationContract]
        List<Varianten> GetAllVarianten();
        [OperationContract]
        List<Versie> GetAllVersies();
        //test
        [OperationContract]
        string InsertEventStatus(EventStatus eventStatus);
        ///eind test
        ///
        [OperationContract]
        string UpdateVoltooid(EventStatus evnt);
    }
    [DataContract]
    public class EventStatus
    {

        int v_cel1, v_cel2, v_cel3, v_cel4, v_cel5, v_cel6, v_cel7, v_cel8, v_cel9, v_cel10, v_cel11, v_cel12, v_cel13, v_cel14, v_cel15, v_cel16, v_cel17, v_cel18, v_cel19, v_cel20, v_cel21, v_cel22, v_cel23, v_cel24, v_cel25;
        string v_cyclusCode;
        string v_eventNaam;
        
        [DataMember]
        public string CyclusCode
        {
            get { return v_cyclusCode; }
            set { v_cyclusCode = value; }
        }
        [DataMember]
        public string EventNaam
        {
            get { return v_eventNaam; }
            set { v_eventNaam = value; }
        }
        [DataMember]
        public int Cel1
        {
            get { return v_cel1; }
            set { v_cel1 = value; }
        }
        [DataMember]
        public int Cel2
        {
            get { return v_cel2; }
            set { v_cel2 = value; }
        }
        [DataMember]
        public int Cel3
        {
            get { return v_cel3; }
            set { v_cel3 = value; }
        }
        [DataMember]
        public int Cel4
        {
            get { return v_cel4; }
            set { v_cel4 = value; }
        }
        [DataMember]
        public int Cel5
        {
            get { return v_cel5; }
            set { v_cel5 = value; }
        }
        [DataMember]
        public int Cel6
        {
            get { return v_cel6; }
            set { v_cel6 = value; }
        }
        [DataMember]
        public int Cel7
        {
            get { return v_cel7; }
            set { v_cel7 = value; }
        }
        [DataMember]
        public int Cel8
        {
            get { return v_cel8; }
            set { v_cel8= value; }
        }
        [DataMember]
        public int Cel9
        {
            get { return v_cel9; }
            set { v_cel9 = value; }
        }
        [DataMember]
        public int Cel10
        {
            get { return v_cel10; }
            set { v_cel10 = value; }
        }
        [DataMember]
        public int Cel11
        {
            get { return v_cel11; }
            set { v_cel11 = value; }
        }
        [DataMember]
        public int Cel12
        {
            get { return v_cel12; }
            set { v_cel12 = value; }
        }
        [DataMember]
        public int Cel13
        {
            get { return v_cel13; }
            set { v_cel13 = value; }
        }
        [DataMember]
        public int Cel14
        {
            get { return v_cel14; }
            set { v_cel14 = value; }
        }
        [DataMember]
        public int Cel15
        {
            get { return v_cel15; }
            set { v_cel15 = value; }
        }
        [DataMember]
        public int Cel16
        {
            get { return v_cel16; }
            set { v_cel16 = value; }
        }
        [DataMember]
        public int Cel17
        {
            get { return v_cel17; }
            set { v_cel17 = value; }
        }
        [DataMember]
        public int Cel18
        {
            get { return v_cel18; }
            set { v_cel18 = value; }
        }
        [DataMember]
        public int Cel19
        {
            get { return v_cel19; }
            set { v_cel19 = value; }
        }
        [DataMember]
        public int Cel20
        {
            get { return v_cel20; }
            set { v_cel20 = value; }
        }
        [DataMember]
        public int Cel21
        {
            get { return v_cel21; }
            set { v_cel21 = value; }
        }
        [DataMember]
        public int Cel22
        {
            get { return v_cel22; }
            set { v_cel22 = value; }
        }
        [DataMember]
        public int Cel23
        {
            get { return v_cel23; }
            set { v_cel23 = value; }
        }
        [DataMember]
        public int Cel24
        {
            get { return v_cel24; }
            set { v_cel24 = value; }
        }
        [DataMember]
        public int Cel25
        {
            get { return v_cel25; }
            set { v_cel25 = value; }
        }

    }
}
