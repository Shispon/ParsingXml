using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ParserXml.Model;

namespace ParserXml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var standards = new List<ProfessionalStandart>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D:\\Job\\NextTry\\NextTry\\ProfessionalStandarts_1647.xml");
            // получим корневой элемент
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xNode in xRoot.GetElementsByTagName("ProfessionalStandart"))
                {
                    ProfessionalStandart standart = new ProfessionalStandart
                    {
                        NameProfessionalStandart = xNode.SelectSingleNode("NameProfessionalStandart")?.InnerText,
                        RegistrationNumber = xNode.SelectSingleNode("RegistrationNumber")?.InnerText,
                        OrderNumber = xNode.SelectSingleNode("OrderNumber")?.InnerText,
                        DateOfApproval = xNode.SelectSingleNode("DateOfApproval")?.InnerText
                    };

                    XmlNode? firstSectionNode = xNode.SelectSingleNode("FirstSection");
                    if (firstSectionNode != null)
                    {
                        FirstSection firstSection = new FirstSection
                        {
                            KindProfessionalActivity = firstSectionNode.SelectSingleNode("KindProfessionalActivity")?.InnerText,
                            CodeKindProfessionalActivity = firstSectionNode.SelectSingleNode("CodeKindProfessionalActivity")?.InnerText,
                            PurposeKindProfessionalActivity = firstSectionNode.SelectSingleNode("PurposeKindProfessionalActivity")?.InnerText
                        };

                        XmlNode? employmentGroupNode = firstSectionNode.SelectSingleNode("EmploymentGroup");
                        if (employmentGroupNode != null)
                        {
                            firstSection.EmploymentGroup = new EmploymentGroup();

                            XmlNode? listOKZNode = employmentGroupNode.SelectSingleNode("ListOKZ");
                            if (listOKZNode != null)
                            {
                                firstSection.EmploymentGroup.ListOKZ = new List<UnitOKZ>();
                                foreach (XmlNode unitOKZNode in listOKZNode.SelectNodes("UnitOKZ"))
                                {
                                    UnitOKZ unitOKZ = new UnitOKZ
                                    {
                                        CodeOKZ = unitOKZNode.SelectSingleNode("CodeOKZ")?.InnerText,
                                        NameOKZ = unitOKZNode.SelectSingleNode("NameOKZ")?.InnerText
                                    };
                                    firstSection.EmploymentGroup.ListOKZ.Add(unitOKZ);
                                }
                            }

                            XmlNode? listOKVEDNode = employmentGroupNode.SelectSingleNode("ListOKVED");
                            if (listOKVEDNode != null)
                            {
                                firstSection.EmploymentGroup.ListOKVED = new List<UnitOKVED>();
                                foreach (XmlNode unitOKVEDNode in listOKVEDNode.SelectNodes("UnitOKVED"))
                                {
                                    UnitOKVED unitOKVED = new UnitOKVED
                                    {
                                        CodeOKVED = unitOKVEDNode.SelectSingleNode("CodeOKVED")?.InnerText,
                                        NameOKVED = unitOKVEDNode.SelectSingleNode("NameOKVED")?.InnerText
                                    };
                                    firstSection.EmploymentGroup.ListOKVED.Add(unitOKVED);
                                }
                            }
                        }
                        standart.FirstSection = firstSection;
                    }

                    standards.Add(standart);
                }

                // Выводим данные
                foreach (var standart in standards)
                {
                    Console.WriteLine($"Name: {standart.NameProfessionalStandart}");
                    Console.WriteLine($"Registration Number: {standart.RegistrationNumber}");
                    Console.WriteLine($"Order Number: {standart.OrderNumber}");
                    Console.WriteLine($"Date of Approval: {standart.DateOfApproval}");

                    if (standart.FirstSection != null)
                    {
                        Console.WriteLine($"Kind of Professional Activity: {standart.FirstSection.KindProfessionalActivity}");
                        Console.WriteLine($"Code of Professional Activity: {standart.FirstSection.CodeKindProfessionalActivity}");
                        Console.WriteLine($"Purpose of Professional Activity: {standart.FirstSection.PurposeKindProfessionalActivity}");

                        if (standart.FirstSection.EmploymentGroup != null)
                        {
                            if (standart.FirstSection.EmploymentGroup.ListOKZ != null)
                            {
                                foreach (var okz in standart.FirstSection.EmploymentGroup.ListOKZ)
                                {
                                    Console.WriteLine($"OKZ Code: {okz.CodeOKZ}, OKZ Name: {okz.NameOKZ}");
                                }
                            }

                            if (standart.FirstSection.EmploymentGroup.ListOKVED != null)
                            {
                                foreach (var okved in standart.FirstSection.EmploymentGroup.ListOKVED)
                                {
                                    Console.WriteLine($"OKVED Code: {okved.CodeOKVED}, OKVED Name: {okved.NameOKVED}");
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
