// -----------------------------------------------------------------------
// <copyright file="ComponentMapping.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace HL7Parser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;


    public class MSH
    {
        public string FieldSeparator { get; set; }                  //	MSH.1  				//		IZ-12:The MSH.1 (Field Separator) field SHALL be valued "|"

        public string EncodingCharacters { get; set; }  		    //  MSH.2 		//			IZ-13:The MSH.2 (Encoding Characters) field SHALL be valued "^~\&"

        public EntitySubcomponentIdentifier SendingApplication { get; set; }  		    //  MSH.3 		//	0361		
        public EntitySubcomponentIdentifier SendingFacility { get; set; }  			    //  MSH.4 		//	0362		
        public EntitySubcomponentIdentifier ReceivingApplication { get; set; }  		    //  MSH.5 	//	0361		
        public EntitySubcomponentIdentifier ReceivingFacility { get; set; }  			    //  MSH.6 	//	0362		
        public string DateTimeOfMessage { get; set; }  			    //  MSH.7 	//			
        public MessageType MessageType { get; set; }  				    //  MSH.9 		//	IZ-17:MSH-9 (Message Type) SHALL contain the constant value "VXU^VO4^VXU_V04"

        public string MessageControlID { get; set; }  			    //  MSH.10	//		
        public string ProcessingID { get; set; }  				    //  MSH.11	//		
        public string VersionID { get; set; }  			            //  MSH.12		//	IZ-15:The MSH-12 (Version ID) SHALL be valued "2.5.1"                                    

        public string AcceptAcknowledgmentType { get; set; }  	    //  MSH.15	//	0155		
        public string ApplicationAcknowledgmentType { get; set; }   //  MSH.16		//	0155		IZ-16:The value of MSH-16 (Application Acknowledgement Type) SHALL be one of the following: AL-always, NE-Never, ER-Error/reject only, SU successful completion only

        public EntityProfileIdentifier MessageProfileIdentifier { get; set; }        //  MSH.21



        public static List<MSH> getMSH(XDocument xDoc)
        {
            var result = (from e in xDoc.Descendants("MSH")
                          select new MSH
                          {
                              FieldSeparator = e.Element("MSH.1") != null ? e.Element("MSH.1").Value : string.Empty,
                              EncodingCharacters = e.Element("MSH.2") != null ? e.Element("MSH.2").Value : string.Empty,

                              SendingApplication = e.Element("MSH.3.1") != null ? e.Descendants("MSH.3").Select(o => new EntitySubcomponentIdentifier
                              {
                                  NamespaceID = o.Element("MSH.3.1") != null ? o.Element("MSH.3.1").Value : string.Empty,
                                  UniversalID = o.Element("MSH.3.2") != null ? o.Element("MSH.3.2").Value : string.Empty,
                                  UniversalIDType = o.Element("MSH.3.3") != null ? o.Element("MSH.3.3").Value : string.Empty,
                              }).SingleOrDefault() : new EntitySubcomponentIdentifier() { NamespaceID = e.Element("MSH.3") != null ? e.Element("MSH.3").Value : string.Empty },

                              SendingFacility = e.Element("MSH.4.1") != null ? e.Descendants("MSH.4").Select(o => new EntitySubcomponentIdentifier
                              {
                                  NamespaceID = o.Element("MSH.4.1") != null ? o.Element("MSH.4.1").Value : string.Empty,
                                  UniversalID = o.Element("MSH.4.2") != null ? o.Element("MSH.4.2").Value : string.Empty,
                                  UniversalIDType = o.Element("MSH.4.3") != null ? o.Element("MSH.4.3").Value : string.Empty,

                              }).SingleOrDefault() : new EntitySubcomponentIdentifier() { NamespaceID = e.Element("MSH.4") != null ? e.Element("MSH.4").Value : string.Empty },

                              ReceivingApplication = e.Element("MSH.5.1") != null ? e.Descendants("MSH.5").Select(o => new EntitySubcomponentIdentifier
                              {
                                  NamespaceID = o.Element("MSH.5.1") != null ? o.Element("MSH.5.1").Value : string.Empty,
                                  UniversalID = o.Element("MSH.5.2") != null ? o.Element("MSH.5.2").Value : string.Empty,
                                  UniversalIDType = o.Element("MSH.5.3") != null ? o.Element("MSH.5.3").Value : string.Empty,
                              }).SingleOrDefault() : new EntitySubcomponentIdentifier() { NamespaceID = e.Element("MSH.5") != null ? e.Element("MSH.5").Value : string.Empty },

                              ReceivingFacility = e.Element("MSH.6.1") != null ? e.Descendants("MSH.6").Select(o => new EntitySubcomponentIdentifier
                              {
                                  NamespaceID = o.Element("MSH.6.1") != null ? o.Element("MSH.6.1").Value : string.Empty,
                                  UniversalID = o.Element("MSH.6.2") != null ? o.Element("MSH.6.2").Value : string.Empty,
                                  UniversalIDType = o.Element("MSH.6.3") != null ? o.Element("MSH.6.3").Value : string.Empty,
                              }).SingleOrDefault() : new EntitySubcomponentIdentifier() { NamespaceID = e.Element("MSH.6") != null ? e.Element("MSH.6").Value : string.Empty },


                              DateTimeOfMessage = e.Element("MSH.7") != null ? e.Element("MSH.7").Value : string.Empty,

                              MessageType = e.Descendants("MSH.9").Select(o => new MessageType
                              {
                                  Message = o.Element("MSH.9.1") != null ? o.Element("MSH.9.1").Value : string.Empty,
                                  TriggerEvent = o.Element("MSH.9.2") != null ? o.Element("MSH.9.2").Value : string.Empty,
                                  MessageStructure = o.Element("MSH.9.3") != null ? o.Element("MSH.9.3").Value : string.Empty,
                              }).SingleOrDefault(),


                              MessageControlID = e.Element("MSH.10") != null ? e.Element("MSH.10").Value : string.Empty,
                              ProcessingID = e.Element("MSH.11") != null ? e.Element("MSH.11").Value : string.Empty,
                              VersionID = e.Element("MSH.12") != null ? e.Element("MSH.12").Value : string.Empty,

                              AcceptAcknowledgmentType = e.Element("MSH.15") != null ? e.Element("MSH.15").Value : string.Empty,
                              ApplicationAcknowledgmentType = e.Element("MSH.16") != null ? e.Element("MSH.16").Value : string.Empty,

                              MessageProfileIdentifier = e.Element("MSH.21.1") != null ? e.Descendants("MSH.21").Select(o => new EntityProfileIdentifier
                              {
                                  EntityIdentifier = o.Element("MSH.21.1") != null ? o.Element("MSH.21.1").Value : string.Empty,
                                  NamespaceID = o.Element("MSH.21.2") != null ? o.Element("MSH.21.2").Value : string.Empty,
                                  UniversalID = o.Element("MSH.21.3") != null ? o.Element("MSH.21.3").Value : string.Empty,
                                  UniversalIDType = o.Element("MSH.21.4") != null ? o.Element("MSH.21.4").Value : string.Empty
                              }).SingleOrDefault() : new EntityProfileIdentifier() { EntityIdentifier = e.Element("MSH.21") != null ? e.Element("MSH.21").Value : string.Empty },

                          }).ToList();
            return result;
           
        }
    }

    public class PID
    {
        public string SetID { get; set; }           //   PID.1 
        public PatientIdentifierList PatientIdentifierList { get; set; }		 //   PID.3 
        public NameComponent PatientName { get; set; }			 //   PID.5 
        public NameComponent MotherMaidenName { get; set; }		 //   PID.6 
        public string DateofBirth { get; set; }			 //   PID.7 
        public string AdministrativeSex { get; set; }		 //   PID.8 
        public CommonCodeComponent Race { get; set; }		 //   PID.10
        public AddressComponent PatientAddress { get; set; }			 //   PID.11
        public PhoneComponent PhoneNumber { get; set; }		 //   PID.13
        public CommonCodeComponent EthnicGroup { get; set; }				//   PID.22
        public string MultipleBirthIndicator { get; set; }			 //   PID.24
        public string BirthOrder { get; set; }			 //   PID.25
        public string PatientDeathDate { get; set; }		 //   PID.29
        public string PatientDeathIndicator { get; set; }          //   PID.30 

        


        public void GetPID(XDocument xDoc)
        {
            var result = (from e in xDoc.Descendants("PID")
                          select new PID
                          {
                              SetID = e.Element("PID.1") != null ? e.Element("PID.1").Value : string.Empty,

                              PatientIdentifierList = e.Element("PID.3.1") != null ? e.Descendants("PID.3").Select(o => new PatientIdentifierList
                              {

                                  IDNumber = o.Element("PID.3.1") != null ? o.Element("PID.3.1").Value : string.Empty,
                                  CheckDigitScheme = o.Element("PID.3.3") != null ? o.Element("PID.3.3").Value : string.Empty,
                                  AssigningAuthority = o.Element("PID.3.4") != null ? o.Element("PID.3.4").Value : string.Empty,
                                  IdentifierTypeCode = o.Element("PID.3.5") != null ? o.Element("PID.3.5").Value : string.Empty,
                              }).SingleOrDefault() : new PatientIdentifierList() { IDNumber = e.Element("PID.3") != null ? e.Element("PID.3").Value : string.Empty },

                              PatientName = e.Element("PID.5.1") != null ? e.Descendants("PID.5").Select(o => new NameComponent
                              {

                                  FamilyName = o.Element("PID.5.1") != null ? o.Element("PID.5.1").Value : string.Empty,
                                  GivenName = o.Element("PID.5.2") != null ? o.Element("PID.5.2").Value : string.Empty,
                                  SecondNames = o.Element("PID.5.3") != null ? o.Element("PID.5.3").Value : string.Empty,
                                  NameTypeCode = o.Element("PID.5.7") != null ? o.Element("PID.5.7").Value : string.Empty,
                              }).SingleOrDefault() : new NameComponent() { FamilyName = e.Element("PID.5") != null ? e.Element("PID.5").Value : string.Empty },

                              MotherMaidenName = e.Element("PID.6.1") != null ? e.Descendants("PID.6").Select(o => new NameComponent
                              {

                                  FamilyName = o.Element("PID.6.1") != null ? o.Element("PID.6.1").Value : string.Empty,
                                  GivenName = o.Element("PID.6.2") != null ? o.Element("PID.6.2").Value : string.Empty,
                                  SecondNames = o.Element("PID.6.3") != null ? o.Element("PID.6.3").Value : string.Empty,
                                  NameTypeCode = o.Element("PID.6.7") != null ? o.Element("PID.6.7").Value : string.Empty,
                              }).SingleOrDefault() : new NameComponent() { FamilyName = e.Element("PID.6") != null ? e.Element("PID.6").Value : string.Empty },

                              DateofBirth = e.Element("PID.7") != null ? e.Element("PID.7").Value : string.Empty,
                              AdministrativeSex = e.Element("PID.8") != null ? e.Element("PID.8").Value : string.Empty,
                              Race = e.Element("PID.10.1") != null ? e.Descendants("PID.10").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("PID.10.1") != null ? o.Element("PID.10.1").Value : string.Empty,
                                  Text = o.Element("PID.10.2") != null ? o.Element("PID.10.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("PID.10.3") != null ? o.Element("PID.10.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("PID.10.4") != null ? o.Element("PID.10.4").Value : string.Empty,
                                  AlternateText = o.Element("PID.10.5") != null ? o.Element("PID.10.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("PID.10.6") != null ? o.Element("PID.10.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("PID.10") != null ? e.Element("PID.10").Value : string.Empty },

                              PatientAddress = e.Element("PID.11.1") != null ? e.Descendants("PID.11").Select(o => new AddressComponent
                              {

                                  StreetAddress = o.Element("PID.11.1") != null ? o.Element("PID.11.1").Value : string.Empty,
                                  OtherDesignation = o.Element("PID.11.2") != null ? o.Element("PID.11.2").Value : string.Empty,
                                  City = o.Element("PID.11.3") != null ? o.Element("PID.11.3").Value : string.Empty,
                                  State = o.Element("PID.11.4") != null ? o.Element("PID.11.4").Value : string.Empty,
                                  Zip = o.Element("PID.11.5") != null ? o.Element("PID.11.5").Value : string.Empty,
                                  Country = o.Element("PID.11.6") != null ? o.Element("PID.11.6").Value : string.Empty,
                                  AddressType = o.Element("PID.11.7") != null ? o.Element("PID.11.7").Value : string.Empty,
                              }).SingleOrDefault() : new AddressComponent() { StreetAddress = e.Element("PID.11") != null ? e.Element("PID.11").Value : string.Empty },

                              PhoneNumber = e.Element("PID.13.2") != null ? e.Descendants("PID.13").Select(o => new PhoneComponent
                              {

                                  TelecommunicationUseCode = o.Element("PID.13.2") != null ? o.Element("PID.13.2").Value : string.Empty,
                                  TelecommunicationEquipmentType = o.Element("PID.13.3") != null ? o.Element("PID.13.3").Value : string.Empty,
                                  EmailAddress = o.Element("PID.13.4") != null ? o.Element("PID.13.4").Value : string.Empty,
                                  AreaCityCode = o.Element("PID.13.6") != null ? o.Element("PID.13.6").Value : string.Empty,
                                  LocalNumber = o.Element("PID.13.7") != null ? o.Element("PID.13.7").Value : string.Empty,

                              }).SingleOrDefault() : new PhoneComponent()
                              {
                                  TelecommunicationUseCode = e.Element("PID.11") != null ? e.Element("PID.11").Value : string.Empty
                              },
                              EthnicGroup = e.Element("PID.22.1") != null ? e.Descendants("PID.22").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("PID.22.1") != null ? o.Element("PID.22.1").Value : string.Empty,
                                  Text = o.Element("PID.22.2") != null ? o.Element("PID.22.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("PID.22.3") != null ? o.Element("PID.22.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("PID.22.4") != null ? o.Element("PID.22.4").Value : string.Empty,
                                  AlternateText = o.Element("PID.22.5") != null ? o.Element("PID.22.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("PID.22.6") != null ? o.Element("PID.22.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("PID.22") != null ? e.Element("PID.22").Value : string.Empty },

                              MultipleBirthIndicator = e.Element("PID.24") != null ? e.Element("PID.24").Value : string.Empty,
                              BirthOrder = e.Element("PID.25") != null ? e.Element("PID.25").Value : string.Empty,
                              PatientDeathDate = e.Element("PID.29") != null ? e.Element("PID.29").Value : string.Empty,
                              PatientDeathIndicator = e.Element("PID.30") != null ? e.Element("PID.30").Value : string.Empty

                          }).ToList();
        }

    }

    public class PD1
    {
        public CommonCodeComponent PublicityCode { get; set; }         //  PD1.11 :
        public string ProtectionIndicator { get; set; }	 //  PD1.12 :
        public string ProtectionIndicatorEffectiveDate { get; set; }     //  PD1.13 :     If PD1-12 (Protection Indicator) is valued	
        public string ImmunizationRegistryStatus { get; set; }		 //  PD1.16 :
        public string ImmunizationRegistryStatusEffectiveDate { get; set; }	 //  PD1.17 :	  If the PD1-16 (Registry Status) field is valued.	
        public string PublicityCodeEffectiveDate { get; set; }         //  PD1.18 :     If the PD1-11 (Publicity Code) field is valued.



        public void GetPD1(XDocument xDoc)
        {
            var result = (from e in xDoc.Descendants("PD1")
                          select new PD1
                          {


                              PublicityCode = e.Element("PD1.11.1") != null ? e.Descendants("PD1.11").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("PD1.11.1") != null ? o.Element("PD1.11.1").Value : string.Empty,
                                  Text = o.Element("PD1.11.2") != null ? o.Element("PD1.11.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("PD1.11.3") != null ? o.Element("PD1.11.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("PD1.11.4") != null ? o.Element("PD1.11.4").Value : string.Empty,
                                  AlternateText = o.Element("PD1.11.5") != null ? o.Element("PD1.11.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("PD1.11.6") != null ? o.Element("PD1.11.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("PD1.11") != null ? e.Element("PD1.11").Value : string.Empty },


                              ProtectionIndicator = e.Element("PD1.12") != null ? e.Element("PD1.12").Value : string.Empty,
                              ProtectionIndicatorEffectiveDate = e.Element("PD1.13") != null ? e.Element("PD1.13").Value : string.Empty,
                              ImmunizationRegistryStatus = e.Element("PD1.16") != null ? e.Element("PD1.16").Value : string.Empty,
                              ImmunizationRegistryStatusEffectiveDate = e.Element("PD1.17") != null ? e.Element("PD1.17").Value : string.Empty,
                              PublicityCodeEffectiveDate = e.Element("PD1.18") != null ? e.Element("PD1.18").Value : string.Empty,
                          }).ToList();
        }
    }

    public class NK1
    {
        public string SetID { get; set; }         //   NK1.1 :
        public NameComponent Name { get; set; }     //   NK1.2 :
        public CommonCodeComponent Relationship { get; set; } //   NK1.3 :	
        public AddressComponent Address { get; set; } 	//   NK1.4 :	
        public PhoneComponent PhoneNumber { get; set; }   //   NK1.5 :




        public void GetNK1(XDocument xDoc)
        {
            var result = (from e in xDoc.Descendants("NK1")
                          select new NK1
                          {
                              SetID = e.Element("NK1.1") != null ? e.Element("NK1.1").Value : string.Empty,

                              Name = e.Element("PID.5.1") != null ? e.Descendants("PID.5").Select(o => new NameComponent
                              {

                                  FamilyName = o.Element("NK1.2.1") != null ? o.Element("NK1.2.1").Value : string.Empty,
                                  GivenName = o.Element("NK1.2.2") != null ? o.Element("NK1.2.2").Value : string.Empty,
                                  SecondNames = o.Element("NK1.2.3") != null ? o.Element("NK1.2.3").Value : string.Empty,
                                  NameTypeCode = o.Element("NK1.2.7") != null ? o.Element("NK1.2.7").Value : string.Empty,
                              }).SingleOrDefault() : new NameComponent() { FamilyName = e.Element("PID.5") != null ? e.Element("PID.5").Value : string.Empty },


                              Relationship = e.Element("NK1.3.1") != null ? e.Descendants("NK1.3").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("NK1.3.1") != null ? o.Element("NK1.3.1").Value : string.Empty,
                                  Text = o.Element("NK1.3.2") != null ? o.Element("NK1.3.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("NK1.3.3") != null ? o.Element("NK1.3.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("NK1.3.4") != null ? o.Element("NK1.3.4").Value : string.Empty,
                                  AlternateText = o.Element("NK1.3.5") != null ? o.Element("NK1.3.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("NK1.3.6") != null ? o.Element("NK1.3.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("NK1.3") != null ? e.Element("NK1.3").Value : string.Empty },

                              Address = e.Element("NK1.4.1") != null ? e.Descendants("NK1.4").Select(o => new AddressComponent
                              {

                                  StreetAddress = o.Element("NK1.4.1") != null ? o.Element("NK1.4.1").Value : string.Empty,
                                  OtherDesignation = o.Element("NK1.4.2") != null ? o.Element("NK1.4.2").Value : string.Empty,
                                  City = o.Element("NK1.4.3") != null ? o.Element("NK1.4.3").Value : string.Empty,
                                  State = o.Element("NK1.4.4") != null ? o.Element("NK1.4.4").Value : string.Empty,
                                  Zip = o.Element("NK1.4.5") != null ? o.Element("NK1.4.5").Value : string.Empty,
                                  Country = o.Element("NK1.4.6") != null ? o.Element("NK1.4.6").Value : string.Empty,
                                  AddressType = o.Element("NK1.4.7") != null ? o.Element("NK1.4.7").Value : string.Empty,
                              }).SingleOrDefault() : new AddressComponent() { StreetAddress = e.Element("NK1.4") != null ? e.Element("NK1.4").Value : string.Empty },

                              PhoneNumber = e.Element("NK1.5.2") != null ? e.Descendants("NK1.5").Select(o => new PhoneComponent
                              {

                                  TelecommunicationUseCode = o.Element("NK1.5.2") != null ? o.Element("NK1.5.2").Value : string.Empty,
                                  TelecommunicationEquipmentType = o.Element("NK1.5.3") != null ? o.Element("NK1.5.3").Value : string.Empty,
                                  EmailAddress = o.Element("NK1.5.4") != null ? o.Element("NK1.5.4").Value : string.Empty,
                                  AreaCityCode = o.Element("NK1.5.6") != null ? o.Element("NK1.5.6").Value : string.Empty,
                                  LocalNumber = o.Element("NK1.5.7") != null ? o.Element("NK1.5.7").Value : string.Empty,

                              }).SingleOrDefault() : new PhoneComponent()
                              {
                                  TelecommunicationUseCode = e.Element("NK1.5") != null ? e.Element("NK1.5").Value : string.Empty
                              }


                          }).ToList();
        }
    }

    public class ORC
    {
        public string OrderControl { get; set; }        //     ORC.1 :  ORC.1 (Order Control) SHALL contain the value "RE"

        public EntityProfileIdentifier PlacerOrderNumber { get; set; }   //		ORC.2 : 
        public EntityProfileIdentifier FillerOrderNumber { get; set; }   //		ORC.3 : 
        public UserProfileIdentifier EnteredBy { get; set; }           //				ORC.10 :
        public UserProfileIdentifier OrderingProvider { get; set; }    //		ORC.12 :  If the first occurrence of RXA-9.1 is valued "00" and RXA-20 is valued "CP" or "PA"


        public void GetORC(XDocument xDoc)
        {
            var result = (from e in xDoc.Descendants("ORC")
                          select new ORC
                          {
                              OrderControl = e.Element("ORC.1") != null ? e.Element("ORC.1").Value : string.Empty,

                              PlacerOrderNumber = e.Element("ORC.2.1") != null ? e.Descendants("ORC.2").Select(o => new EntityProfileIdentifier
                              {
                                  EntityIdentifier = o.Element("ORC.2.1") != null ? o.Element("ORC.2.1").Value : string.Empty,
                                  NamespaceID = o.Element("ORC.2.2") != null ? o.Element("ORC.2.2").Value : string.Empty,
                                  UniversalID = o.Element("ORC.2.3") != null ? o.Element("ORC.2.3").Value : string.Empty,
                                  UniversalIDType = o.Element("ORC.2.4") != null ? o.Element("ORC.2.4").Value : string.Empty
                              }).SingleOrDefault() : new EntityProfileIdentifier() { EntityIdentifier = e.Element("ORC.2") != null ? e.Element("ORC.2").Value : string.Empty },

                              FillerOrderNumber = e.Element("ORC.3.1") != null ? e.Descendants("ORC.3").Select(o => new EntityProfileIdentifier
                              {
                                  EntityIdentifier = o.Element("ORC.3.1") != null ? o.Element("ORC.3.1").Value : string.Empty,
                                  NamespaceID = o.Element("ORC.3.2") != null ? o.Element("ORC.3.2").Value : string.Empty,
                                  UniversalID = o.Element("ORC.3.3") != null ? o.Element("ORC.3.3").Value : string.Empty,
                                  UniversalIDType = o.Element("ORC.3.4") != null ? o.Element("ORC.3.4").Value : string.Empty
                              }).SingleOrDefault() : new EntityProfileIdentifier() { EntityIdentifier = e.Element("ORC.3") != null ? e.Element("ORC.3").Value : string.Empty },

                              EnteredBy = e.Element("ORC.10.1") != null ? e.Descendants("ORC.10").Select(o => new UserProfileIdentifier
                              {
                                  IDNumber = o.Element("ORC.10.1") != null ? o.Element("ORC.10.1").Value : string.Empty,
                                  FamilyName = o.Element("ORC.10.2") != null ? o.Element("ORC.10.2").Value : string.Empty,
                                  GivenName = o.Element("ORC.10.3") != null ? o.Element("ORC.10.3").Value : string.Empty,
                                  SecondName = o.Element("ORC.10.4") != null ? o.Element("ORC.10.4").Value : string.Empty,

                                  AssigningAuthority = o.Element("ORC.10.9.1") != null ? o.Descendants("ORC.10.9").Select(d => new EntitySubcomponentIdentifier
                                  {

                                      NamespaceID = d.Element("ORC.10.9.1") != null ? d.Element("ORC.10.9.1").Value : string.Empty,
                                      UniversalID = d.Element("ORC.10.9.2") != null ? d.Element("ORC.10.9.2").Value : string.Empty,
                                      UniversalIDType = d.Element("ORC.10.9.3") != null ? d.Element("ORC.10.9.3").Value : string.Empty
                                  }).SingleOrDefault() : new EntitySubcomponentIdentifier() { NamespaceID = o.Element("ORC.10.9") != null ? o.Element("ORC.10.9").Value : string.Empty },

                                  NameTypeCode = o.Element("ORC.10.10") != null ? o.Element("ORC.10.10").Value : string.Empty,
                                  CheckDigitScheme = o.Element("ORC.10.12") != null ? o.Element("ORC.10.12").Value : string.Empty,
                              }).SingleOrDefault() : new UserProfileIdentifier() { IDNumber = e.Element("ORC.10") != null ? e.Element("ORC.10").Value : string.Empty },


                              OrderingProvider = e.Element("ORC.12.1") != null ? e.Descendants("ORC.12").Select(o => new UserProfileIdentifier
                              {
                                  IDNumber = o.Element("ORC.12.1") != null ? o.Element("ORC.12.1").Value : string.Empty,
                                  FamilyName = o.Element("ORC.12.2") != null ? o.Element("ORC.12.2").Value : string.Empty,
                                  GivenName = o.Element("ORC.12.3") != null ? o.Element("ORC.12.3").Value : string.Empty,
                                  SecondName = o.Element("ORC.12.4") != null ? o.Element("ORC.12.4").Value : string.Empty,

                                  AssigningAuthority = o.Element("ORC.12.9.1") != null ? o.Descendants("ORC.12.9").Select(d => new EntitySubcomponentIdentifier
                                  {

                                      NamespaceID = d.Element("ORC.12.9.1") != null ? d.Element("ORC.12.9.1").Value : string.Empty,
                                      UniversalID = d.Element("ORC.12.9.2") != null ? d.Element("ORC.10.9.2").Value : string.Empty,
                                      UniversalIDType = d.Element("ORC.12.9.3") != null ? d.Element("ORC.12.9.3").Value : string.Empty
                                  }).SingleOrDefault() : new EntitySubcomponentIdentifier() { NamespaceID = o.Element("ORC.12.9") != null ? o.Element("ORC.12.9").Value : string.Empty },

                                  NameTypeCode = o.Element("ORC.12.10") != null ? o.Element("ORC.12.10").Value : string.Empty,
                                  CheckDigitScheme = o.Element("ORC.12.12") != null ? o.Element("ORC.12.12").Value : string.Empty,
                              }).SingleOrDefault() : new UserProfileIdentifier() { IDNumber = e.Element("ORC.12") != null ? e.Element("ORC.12").Value : string.Empty },




                          }).ToList();
        }

    }

    public class RXA
    {

        public string SubIDCounter { get; set; } //RXA.1 : 	( Give Sub-id counter) ) SHALL be valued "0" Note that "0" is zero.

        public string AdministrationSubIDCounter { get; set; } //RXA.2 : 		RXA-2 (admin Sub-id) SHALL be valued "1"

        public string DateStartofAdministration { get; set; } //RXA.3 : 	
        public string DateEndofAdministration { get; set; } //RXA.4 : 		If RXA-4 (Date time of admin end ) is populated, then it SHALL be the same as Start time (RXA-3)

        public CommonCodeComponent AdministeredCode { get; set; } //RXA.5 : 	CVX		
        public string AdministeredAmount { get; set; } //RXA.6 : 
        public CommonCodeComponent AdministeredUnits { get; set; } //RXA.7 : 	UCUM	If Administered Amount is not valued "999"	
        public CommonCodeComponent AdministrationNotes { get; set; } //RXA.9 : 		If RXA-20 is valued "CP" or "PA"	
        public UserProfileIdentifier AdministeringProvider { get; set; } //RXA.10 :
        public Location AdministeredatLocation { get; set; } //RXA.11 :
        public string SubstanceLotNumber { get; set; } //RXA.15 :		If the first occurrence of RXA-9.1 is valued "00" and RXA-20 is valued "CP" or "PA"	
        public string SubstanceExpirationDate { get; set; } //RXA.16 :	If the RXA-15 (lot number) is valued	
        public CommonCodeComponent SubstanceManufacturerName { get; set; } //RXA.17 :		MVX	If the first occurrence of RXA-9.1 is valued "00" and RXA-20 is valued "CP" or "PA"	
        public CommonCodeComponent SubstanceTreatmentRefusalReason { get; set; } //RXA.18 :	If the RXA-20 (Completion Status) is valued "RE"	IZ-32:If the RXA-18 (Refusal Reason) is populated, RXA-20 (completion Status) SHALL be valued to "RE".

        public string CompletionStatus { get; set; } //RXA.20 :	If RXA-5.1 (vaccine administered) has a CVX of 998 (no vaccine administered) then RXA-20 shall be populated with "NA".

        public string ActionCode { get; set; } //RXA.21 :


        public void GetRXA(XDocument xDoc)
        {
            var result = (from e in xDoc.Descendants("RXA")
                          select new RXA
                          {
                              SubIDCounter = e.Element("RXA.1") != null ? e.Element("RXA.1").Value : string.Empty,
                              AdministrationSubIDCounter = e.Element("RXA.2") != null ? e.Element("RXA.2").Value : string.Empty,

                              DateStartofAdministration = e.Element("RXA.3") != null ? e.Element("RXA.3").Value : string.Empty,
                              DateEndofAdministration = e.Element("RXA.4") != null ? e.Element("RXA.5").Value : string.Empty,

                              AdministeredCode = e.Element("RXA.5.1") != null ? e.Descendants("RXA.5").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("RXA.5.1") != null ? o.Element("RXA.5.1").Value : string.Empty,
                                  Text = o.Element("RXA.5.2") != null ? o.Element("RXA.5.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("RXA.5.3") != null ? o.Element("RXA.5.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("RXA.5.4") != null ? o.Element("RXA.5.4").Value : string.Empty,
                                  AlternateText = o.Element("RXA.5.5") != null ? o.Element("RXA.5.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("RXA.5.6") != null ? o.Element("RXA.5.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("RXA.5") != null ? e.Element("RXA.5").Value : string.Empty },

                              AdministeredAmount = e.Element("RXA.6") != null ? e.Element("RXA.6").Value : string.Empty,
                              AdministeredUnits = e.Element("RXA.5.1") != null ? e.Descendants("RXA.5").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("RXA.5.1") != null ? o.Element("RXA.5.1").Value : string.Empty,
                                  Text = o.Element("RXA.5.2") != null ? o.Element("RXA.5.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("RXA.5.3") != null ? o.Element("RXA.5.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("RXA.5.4") != null ? o.Element("RXA.5.4").Value : string.Empty,
                                  AlternateText = o.Element("RXA.5.5") != null ? o.Element("RXA.5.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("RXA.5.6") != null ? o.Element("RXA.5.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("RXA.5") != null ? e.Element("RXA.5").Value : string.Empty },
                              AdministrationNotes = e.Element("RXA.5.1") != null ? e.Descendants("RXA.5").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("RXA.5.1") != null ? o.Element("RXA.5.1").Value : string.Empty,
                                  Text = o.Element("RXA.5.2") != null ? o.Element("RXA.5.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("RXA.5.3") != null ? o.Element("RXA.5.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("RXA.5.4") != null ? o.Element("RXA.5.4").Value : string.Empty,
                                  AlternateText = o.Element("RXA.5.5") != null ? o.Element("RXA.5.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("RXA.5.6") != null ? o.Element("RXA.5.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("RXA.5") != null ? e.Element("RXA.5").Value : string.Empty },

                              AdministeringProvider = e.Element("RXA.10.1") != null ? e.Descendants("RXA.10").Select(o => new UserProfileIdentifier
                              {
                                  IDNumber = o.Element("RXA.10.1") != null ? o.Element("RXA.10.1").Value : string.Empty,
                                  FamilyName = o.Element("RXA.10.2") != null ? o.Element("RXA.10.2").Value : string.Empty,
                                  GivenName = o.Element("RXA.10.3") != null ? o.Element("RXA.10.3").Value : string.Empty,
                                  SecondName = o.Element("RXA.10.4") != null ? o.Element("RXA.10.4").Value : string.Empty,

                                  AssigningAuthority = o.Element("RXA.10.9.1") != null ? o.Descendants("RXA.10.9").Select(d => new EntitySubcomponentIdentifier
                                  {

                                      NamespaceID = d.Element("RXA.10.9.1") != null ? d.Element("RXA.10.9.1").Value : string.Empty,
                                      UniversalID = d.Element("RXA.10.9.2") != null ? d.Element("RXA.10.9.2").Value : string.Empty,
                                      UniversalIDType = d.Element("RXA.10.9.3") != null ? d.Element("RXA.10.9.3").Value : string.Empty
                                  }).SingleOrDefault() : new EntitySubcomponentIdentifier() { NamespaceID = o.Element("RXA.10.9") != null ? o.Element("RXA.10.9").Value : string.Empty },

                                  NameTypeCode = o.Element("RXA.10.10") != null ? o.Element("RXA.10.10").Value : string.Empty,
                                  CheckDigitScheme = o.Element("RXA.10.12") != null ? o.Element("RXA.10.12").Value : string.Empty,
                              }).SingleOrDefault() : new UserProfileIdentifier() { IDNumber = e.Element("RXA.10") != null ? e.Element("RXA.10").Value : string.Empty },

                              AdministeredatLocation = e.Element("RXA.11.4") != null ? e.Descendants("RXA.11").Select(o => new Location
                              {
                                  Facility = o.Element("RXA.11.4.1") != null ? o.Descendants("RXA.11.4").Select(d => new EntitySubcomponentIdentifier
                                  {
                                      NamespaceID = d.Element("RXA.11.4.1") != null ? d.Element("RXA.11.4.1").Value : string.Empty,
                                      UniversalID = d.Element("RXA.11.4.2") != null ? d.Element("RXA.11.4.2").Value : string.Empty,
                                      UniversalIDType = d.Element("RXA.11.4.3") != null ? d.Element("RXA.11.4.3").Value : string.Empty,

                                  }).SingleOrDefault() : new EntitySubcomponentIdentifier() { NamespaceID = o.Element("RXA.11.4.9") != null ? o.Element("RXA.11.4.9").Value : string.Empty },

                              }).SingleOrDefault() : new Location() { Facility = new EntitySubcomponentIdentifier() { NamespaceID = e.Element("RXA.11") != null ? e.Element("RXA.11").Value : string.Empty } },
                              SubstanceLotNumber = e.Element("RXA.15") != null ? e.Element("RXA.15").Value : string.Empty,
                              SubstanceExpirationDate = e.Element("RXA.16") != null ? e.Element("RXA.16").Value : string.Empty,
                              SubstanceManufacturerName = e.Element("RXA.17.1") != null ? e.Descendants("RXA.17").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("RXA.17.1") != null ? o.Element("RXA.17.1").Value : string.Empty,
                                  Text = o.Element("RXA.17.2") != null ? o.Element("RXA.17.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("RXA.17.3") != null ? o.Element("RXA.17.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("RXA.17.4") != null ? o.Element("RXA.17.4").Value : string.Empty,
                                  AlternateText = o.Element("RXA.17.5") != null ? o.Element("RXA.17.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("RXA.17.6") != null ? o.Element("RXA.17.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("RXA.17") != null ? e.Element("RXA.17").Value : string.Empty },


                              SubstanceTreatmentRefusalReason = e.Element("RXA.18.1") != null ? e.Descendants("RXA.18").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("RXA.18.1") != null ? o.Element("RXA.18.1").Value : string.Empty,
                                  Text = o.Element("RXA.18.2") != null ? o.Element("RXA.18.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("RXA.18.3") != null ? o.Element("RXA.18.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("RXA.18.4") != null ? o.Element("RXA.18.4").Value : string.Empty,
                                  AlternateText = o.Element("RXA.18.5") != null ? o.Element("RXA.18.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("RXA.18.6") != null ? o.Element("RXA.18.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("RXA.18") != null ? e.Element("RXA.18").Value : string.Empty },

                              CompletionStatus = e.Element("RXA.20") != null ? e.Element("RXA.20").Value : string.Empty,

                              ActionCode = e.Element("RXA.21") != null ? e.Element("RXA.21").Value : string.Empty
                              
                          }).ToList();
          }
    }

    public class RXR
    {
        public CommonCodeComponent Route { get; set; }               //RXR.1 :	
        public CommonCodeComponent AdministrationSite { get; set; }	//RXR.2 : 



        public void GetRXR(XDocument xDoc)
        {
            var result = (from e in xDoc.Descendants("RXR")
                          select new RXR
                          {
                              Route = e.Element("RXR.1.1") != null ? e.Descendants("RXR.1").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("RXR.1.1") != null ? o.Element("RXR.1.1").Value : string.Empty,
                                  Text = o.Element("RXR.1.2") != null ? o.Element("RXR.1.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("RXR.1.3") != null ? o.Element("RXR.1.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("RXR.1.4") != null ? o.Element("RXR.1.4").Value : string.Empty,
                                  AlternateText = o.Element("RXR.1.5") != null ? o.Element("RXR.1.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("RXR.1.6") != null ? o.Element("RXR.1.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("RXR.1") != null ? e.Element("RXR.1").Value : string.Empty },

                              AdministrationSite = e.Element("RXR.2.1") != null ? e.Descendants("RXR.2").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("RXR.2.1") != null ? o.Element("RXR.2.1").Value : string.Empty,
                                  Text = o.Element("RXR.2.2") != null ? o.Element("RXR.2.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("RXR.2.3") != null ? o.Element("RXR.2.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("RXR.2.4") != null ? o.Element("RXR.2.4").Value : string.Empty,
                                  AlternateText = o.Element("RXR.2.5") != null ? o.Element("RXR.2.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("RXR.2.6") != null ? o.Element("RXR.2.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("RXR.2") != null ? e.Element("RXR.2").Value : string.Empty },

                          }).ToList();
        }
    }

    public class OBX
    {
        public string SetIDOBX { get; set; } // OBX.1 : 	IZ-20:The Value of OBX-1 (Set ID-OBX) SHALL be valued sequentially starting with the value "1" within a given segment group.
        public string ValueType { get; set; } // OBX.2 : 	IZ-21:The value of OBX-2 (Value Type) SHALL be one of the following: CE, NM, ST, DT, ID or TS
        public CommonCodeComponent ObservationIdentifier { get; set; } // OBX.3 : 	NIP003		
        public string ObservationSubID { get; set; } // OBX.4 : 
        public string ObservationValue { get; set; } // OBX.5 : 	IZ-37:If OBX-3.1 is "30956-7" and OBX-2 is "CE" then the value set for OBX-5 shall be CVX.
                                                     //IZ-36:If OBX-3.1 is "69764-9" and OBX-2 is "CE" then the value set for OBX-5 shall be cdcgs1vis.         
                                                     //IZ-35:If OBX-3.1 is "64994-7" and OBX-2 is "CE" then the value set for OBX-5 shall be HL70064.
        public CommonCodeComponent Units { get; set; } // OBX.6 : 	If OBX-2(Value Type) is valued "NM" or "SN"	
        public string ObservationResultStatus { get; set; } // OBX.11 :		IZ-22:The value of OBX-11 (Observation Result Status) SHALL be "F"
        public string DateoftheObservation { get; set; } // OBX.14 :		
        public CommonCodeComponent ObservationMethod { get; set; } // OBX.17 :			PHVS_FundingEligibilityObsMethod_IIS	If OBX-3.1 is "64994-7"	



        public void GetOBX(XDocument xDoc)
        {
            var result = (from e in xDoc.Descendants("OBX")
                          select new OBX
                          {
                              SetIDOBX = e.Element("OBX.1") != null ? e.Element("OBX.1").Value : string.Empty,

                              ValueType = e.Element("OBX.2") != null ? e.Element("OBX.2").Value : string.Empty,
                              ObservationIdentifier = e.Element("OBX.3.1") != null ? e.Descendants("OBX.3").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("OBX.3.1") != null ? o.Element("OBX.3.1").Value : string.Empty,
                                  Text = o.Element("OBX.3.2") != null ? o.Element("OBX.3.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("OBX.3.3") != null ? o.Element("OBX.3.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("OBX.3.4") != null ? o.Element("OBX.3.4").Value : string.Empty,
                                  AlternateText = o.Element("OBX.3.5") != null ? o.Element("OBX.3.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("OBX.3.6") != null ? o.Element("OBX.3.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("OBX.3") != null ? e.Element("OBX.3").Value : string.Empty },
                              ObservationSubID = e.Element("OBX.4") != null ? e.Element("OBX.4").Value : string.Empty,
                              ObservationValue = e.Element("OBX.5") != null ? e.Element("OBX.5").Value : string.Empty,
                              Units = e.Element("OBX.6.1") != null ? e.Descendants("OBX.6").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("OBX.6.1") != null ? o.Element("OBX.6.1").Value : string.Empty,
                                  Text = o.Element("OBX.6.2") != null ? o.Element("OBX.6.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("OBX.6.3") != null ? o.Element("OBX.6.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("OBX.6.4") != null ? o.Element("OBX.6.4").Value : string.Empty,
                                  AlternateText = o.Element("OBX.6.5") != null ? o.Element("OBX.6.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("OBX.3.6") != null ? o.Element("OBX.3.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("OBX.6") != null ? e.Element("OBX.6").Value : string.Empty },

                              ObservationResultStatus = e.Element("OBX.11") != null ? e.Element("OBX.11").Value : string.Empty,
                              DateoftheObservation = e.Element("OBX.14") != null ? e.Element("OBX.14").Value : string.Empty,
                              ObservationMethod = e.Element("OBX.17.1") != null ? e.Descendants("OBX.17").Select(o => new CommonCodeComponent
                              {

                                  Identifier = o.Element("OBX.17.1") != null ? o.Element("OBX.17.1").Value : string.Empty,
                                  Text = o.Element("OBX.17.2") != null ? o.Element("OBX.17.2").Value : string.Empty,
                                  NameofCodingSystem = o.Element("OBX.17.3") != null ? o.Element("OBX.17.3").Value : string.Empty,
                                  AlternateIdentifier = o.Element("OBX.17.4") != null ? o.Element("OBX.17.4").Value : string.Empty,
                                  AlternateText = o.Element("OBX.17.5") != null ? o.Element("OBX.17.5").Value : string.Empty,
                                  NameofAlternateCodingSystem = o.Element("OBX.17.6") != null ? o.Element("OBX.17.6").Value : string.Empty,
                              }).SingleOrDefault() : new CommonCodeComponent() { Identifier = e.Element("OBX.17") != null ? e.Element("OBX.17").Value : string.Empty }

                          }).ToList();
        }

    }

    public class NTE
    {
        public string Comment { get; set; } //NTE.3 :

        public void GetNTE(XDocument xDoc)
        {
            var result = (from e in xDoc.Descendants("NTE")
                          select new NTE
                          {
                              Comment = e.Element("NTE.3") != null ? e.Element("NTE.3").Value : string.Empty,
                          }).ToList();
        }
    }


    #region Common Classes 

    public class PatientIdentifierList
        {
            public string IDNumber { get; set; } //  PID.3.1 :
            public string CheckDigitScheme { get; set; } //  PID.3.3 :If CX.2 (check digit) is valued	
            public string AssigningAuthority { get; set; } //  PID.3.4 : 
            public string IdentifierTypeCode { get; set; } //  PID.3.5 :
        }
    public class MessageType
        {
            public string Message { get; set; } // MSH.9.1 :
            public string TriggerEvent { get; set; } // MSH.9.2 :
            public string MessageStructure { get; set; } // MSH.9.3 :
        }

    public class Location
    {
        public EntitySubcomponentIdentifier Facility { get; set; }  //RXA.11.4 :
    }

    public class EntityProfileIdentifier
    {
        public string EntityIdentifier { get; set; }	//MSH.21.1 :  	
        public string NamespaceID { get; set; }	//MSH.21.2 :  If EI.3 (Universal Id) is not valued	
        public string UniversalID { get; set; }	//MSH.21.3 :  If EI.1 (Namespace ID) is not valued	IZ-3:If populated EI.3 (Universal Id), it shall be valued with an ISO-compliant OID.
        public string UniversalIDType { get; set; }	//MSH.21.4 :  

    }

    public class EntitySubcomponentIdentifier
    {
        public string NamespaceID { get; set; } // ORC.10.9.1 	If the HD.2 (Universal ID) is not valued	
        public string UniversalID { get; set; } // ORC.10.9.2 	If the HD.1 (Namespace ID) is not valued	IZ-5:If populated, HD.2 (Universal ID) it SHALL be valued with an ISO_compliant OID.
        public string UniversalIDType { get; set; } // ORC.10.9.3 	If the HD.2 (Universal ID) is valued	IZ-6:If populated, HD.3 (Universal ID Type) SHALL be valued the literal value: "ISO".
    }

    public class AddressComponent
    {
        public string StreetAddress { get; set; } // PID.11.1 :
        public string OtherDesignation { get; set; } // PID.11.2 : 
        public string City { get; set; } // PID.11.3 :
        public string State { get; set; } // PID.11.4 :	US Postal Service State Codes		
        public string Zip { get; set; } // PID.11.5 :
        public string Country { get; set; } // PID.11.6 :
        public string AddressType { get; set; } // PID.11.7 :
    }

    public class PhoneComponent
    {
        public string TelecommunicationUseCode { get; set; } // PID.13.2 :0201		
        public string TelecommunicationEquipmentType { get; set; } // PID.13.3 :0202		
        public string EmailAddress { get; set; } // PID.13.4 :If the XTN-2 (telecommunication type code) is valued "NET"	
        public string AreaCityCode { get; set; } // PID.13.6 :If the XTN-2 (telecommunication type code) is valued not "NET"	
        public string LocalNumber { get; set; } // PID.13.7 :If the XTN-2 (telecommunication type code) is valued not "NET"
    }

    public class CommonCodeComponent
    {
        
        public string Identifier { get; set; } // PID.22.1 :
        public string Text { get; set; } // PID.22.2 :
        public string NameofCodingSystem { get; set; } // PID.22.3 :
        public string AlternateIdentifier { get; set; } // PID.22.4 :
        public string AlternateText { get; set; } // PID.22.5 :
        public string NameofAlternateCodingSystem { get; set; } // PID.22.6 :	If CE.4 (Alternate Identifier) is valued.
    }

    public class NameComponent
    {
        public string FamilyName { get; set; } // PID.5.1 : 
        public string GivenName { get; set; } // PID.5.2 : 	
        public string SecondNames { get; set; } // PID.5.3 : 	
        public string NameTypeCode { get; set; } // PID.5.7 : 
    }

    public class UserProfileIdentifier
    {
        public string IDNumber { get; set; } // ORC.10.1 : 		If XCN.2.1 (Surname) and XCN.3 (Given Name) are not valued	
        public string FamilyName { get; set; } // ORC.10.2 : 
        public string GivenName { get; set; } // ORC.10.3 : 
        public string SecondName { get; set; } // ORC.10.4 : 
        public EntitySubcomponentIdentifier AssigningAuthority { get; set; } // ORC.10.9 : 		If the XCN-1 (id number) is valued	
        public string NameTypeCode { get; set; } // ORC.10.10 :
        public string CheckDigitScheme { get; set; } // ORC.10.12 :	If XCN-11 (check digit identifier) is valued
    }


    #endregion


   public class HL7Client
   {
       private List<MSH> _MSH;
       public HL7Client() { }
       private HL7Client(XDocument xDoc)
       {

           this._MSH = MSH.getMSH(xDoc);
           
       }
       public HL7Client Start(XDocument xDoc)
       {
           return new HL7Client(xDoc);
       }
   }
    


}
