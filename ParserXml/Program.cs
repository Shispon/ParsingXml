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
            xDoc.Load("C:\\Users\\Shispon\\source\\repos\\ParsingXml\\ParserXml\\ProfessionalStandarts_1647.xml");
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

                    XmlNode? thirdSectionNode = xNode.SelectSingleNode("ThirdSection");
                    if (thirdSectionNode != null)
                    {
                        ThirdSection thirdSection = new ThirdSection();

                        XmlNode? workFunctionNode = thirdSectionNode.SelectSingleNode("WorkFunctions");
                        if (workFunctionNode != null)
                        {
                            thirdSection.WorkFunction = new WorkFunctions();

                            XmlNode? generalizedWorkFunctionsNode = workFunctionNode.SelectSingleNode("GeneralizedWorkFunctions");
                            if (generalizedWorkFunctionsNode != null)
                            {
                                GeneralizedWorkFunctions generalizedWorkFunctions = new GeneralizedWorkFunctions
                                {
                                    generalizedWorkFunctions = new List<GeneralizedWorkFunction>()
                                };

                                foreach (XmlNode generalizedWorkFunctionNode in generalizedWorkFunctionsNode.SelectNodes("GeneralizedWorkFunction"))
                                {
                                    GeneralizedWorkFunction generalizedWorkFunction = new GeneralizedWorkFunction
                                    {
                                        CodeOTF = new List<string>(),
                                        NameOTF = new List<string>(),
                                        PossibleJobTitles = new PossibleJobTitles
                                        {
                                            PossibleJobTitle = new List<string>()
                                        },
                                        EducationalRequirements = new EducationalRequirements
                                        {
                                            EducationalRequirement = new List<string>()
                                        },
                                        RequirementsWorkExperiences = new RequirementsWorkExperiences
                                        {
                                            RequirementsWorkExperience = new List<string>()
                                        },
                                        SpecialConditionsForAdmissionToWorks = new SpecialConditionsForAdmissionToWorks
                                        {
                                            SpecialConditionForAdmissionToWork = new List<string>()
                                        },
                                        OtherCharacteristics = new OtherCharacteristics
                                        {
                                            OtherCharacteristic = new List<string>()
                                        },
                                        OtherCharacteristicPlus = new OtherCharacteristicPlus
                                        {
                                            ListOKZ = new List<UnitOKZ>(),
                                            ListEKS = new List<UnitEKS>(),
                                            ListOKPDTR = new List<UnitOKPDTR>(),
                                            ListOKSO = new List<UnitOKSO>()
                                        },
                                        ParticularWorkFunctions = new List<ParticularWorkFunctions>()
                                    };

                                    foreach (XmlNode childNode in generalizedWorkFunctionNode.ChildNodes)
                                    {
                                        if (childNode.Name == "CodeOTF")
                                        {
                                            generalizedWorkFunction.CodeOTF.Add(childNode.InnerText);
                                        }
                                        else if (childNode.Name == "NameOTF")
                                        {
                                            generalizedWorkFunction.NameOTF.Add(childNode.InnerText);
                                        }
                                        else if (childNode.Name == "PossibleJobTitles")
                                        {
                                            foreach (XmlNode titleNode in childNode.SelectNodes("PossibleJobTitle"))
                                            {
                                                generalizedWorkFunction.PossibleJobTitles.PossibleJobTitle.Add(titleNode.InnerText);
                                            }
                                        }
                                        else if (childNode.Name == "EducationalRequirements")
                                        {
                                            foreach (XmlNode requirementNode in childNode.SelectNodes("EducationalRequirement"))
                                            {
                                                generalizedWorkFunction.EducationalRequirements.EducationalRequirement.Add(requirementNode.InnerText);
                                            }
                                        }
                                        else if (childNode.Name == "RequirementsWorkExperiences")
                                        {
                                            foreach (XmlNode experienceNode in childNode.SelectNodes("RequirementsWorkExperience"))
                                            {
                                                generalizedWorkFunction.RequirementsWorkExperiences.RequirementsWorkExperience.Add(experienceNode.InnerText);
                                            }
                                        }
                                        else if (childNode.Name == "SpecialConditionsForAdmissionToWorks")
                                        {
                                            foreach (XmlNode conditionNode in childNode.SelectNodes("SpecialConditionForAdmissionToWork"))
                                            {
                                                generalizedWorkFunction.SpecialConditionsForAdmissionToWorks.SpecialConditionForAdmissionToWork.Add(conditionNode.InnerText);
                                            }
                                        }
                                        else if (childNode.Name == "OtherCharacteristics")
                                        {
                                            foreach (XmlNode characteristicNode in childNode.SelectNodes("OtherCharacteristic"))
                                            {
                                                generalizedWorkFunction.OtherCharacteristics.OtherCharacteristic.Add(characteristicNode.InnerText);
                                            }
                                        }
                                        else if (childNode.Name == "OtherCharacteristicPlus")
                                        {
                                            foreach (XmlNode listNode in childNode.ChildNodes)
                                            {
                                                if (listNode.Name == "ListOKZ")
                                                {
                                                    foreach (XmlNode unitOKZNode in listNode.SelectNodes("UnitOKZ"))
                                                    {
                                                        UnitOKZ unitOKZ = new UnitOKZ
                                                        {
                                                            CodeOKZ = unitOKZNode.SelectSingleNode("CodeOKZ")?.InnerText,
                                                            NameOKZ = unitOKZNode.SelectSingleNode("NameOKZ")?.InnerText
                                                        };
                                                        generalizedWorkFunction.OtherCharacteristicPlus.ListOKZ.Add(unitOKZ);
                                                    }
                                                }
                                                else if (listNode.Name == "ListEKS")
                                                {
                                                    foreach (XmlNode unitEKSNode in listNode.SelectNodes("UnitEKS"))
                                                    {
                                                        UnitEKS unitEKS = new UnitEKS
                                                        {
                                                            CodeEKS = unitEKSNode.SelectSingleNode("CodeEKS")?.InnerText,
                                                            NameEKS = unitEKSNode.SelectSingleNode("NameEKS")?.InnerText
                                                        };
                                                        generalizedWorkFunction.OtherCharacteristicPlus.ListEKS.Add(unitEKS);
                                                    }
                                                }
                                                else if (listNode.Name == "ListOKPDTR")
                                                {
                                                    foreach (XmlNode unitOKPDTRNode in listNode.SelectNodes("UnitOKPDTR"))
                                                    {
                                                        UnitOKPDTR unitOKPDTR = new UnitOKPDTR
                                                        {
                                                            CodeOKPDTR = unitOKPDTRNode.SelectSingleNode("CodeOKPDTR")?.InnerText,
                                                            NameOKPDTR = unitOKPDTRNode.SelectSingleNode("NameOKPDTR")?.InnerText
                                                        };
                                                        generalizedWorkFunction.OtherCharacteristicPlus.ListOKPDTR.Add(unitOKPDTR);
                                                    }
                                                }
                                                else if (listNode.Name == "ListOKSO")
                                                {
                                                    foreach (XmlNode unitOKSONode in listNode.SelectNodes("UnitOKSO"))
                                                    {
                                                        UnitOKSO unitOKSO = new UnitOKSO
                                                        {
                                                            CodeOKSO = unitOKSONode.SelectSingleNode("CodeOKSO")?.InnerText,
                                                            NameOKSO = unitOKSONode.SelectSingleNode("NameOKSO")?.InnerText
                                                        };
                                                        generalizedWorkFunction.OtherCharacteristicPlus.ListOKSO.Add(unitOKSO);
                                                    }
                                                }
                                            }
                                        }
                                        else if (childNode.Name == "ParticularWorkFunctions")
                                        {
                                            ParticularWorkFunctions particularWorkFunctions = new ParticularWorkFunctions
                                            {
                                                particularWorkFunction = new List<ParticularWorkFunction>()
                                            };

                                            foreach (XmlNode particularWorkFunctionNode in childNode.SelectNodes("ParticularWorkFunction"))
                                            {
                                                ParticularWorkFunction particularWorkFunction = new ParticularWorkFunction
                                                {
                                                    codeTF = new List<string>(),
                                                    nameTF = new List<string>(),
                                                    subQualification = new List<string>(),
                                                    laborActions = new LaborActions
                                                    {
                                                        laborActions = new List<string>()
                                                    },
                                                    requiredSkills = new RequiredSkills
                                                    {
                                                        RequiredSkill = new List<string>()
                                                    },
                                                    necessaryKnowledges = new NecessaryKnowledges
                                                    {
                                                        NecessaryKnowledge = new List<string>()
                                                    },
                                                    otherCharacteristics = new OtherCharacteristics
                                                    {
                                                        OtherCharacteristic = new List<string>()
                                                    }
                                                };

                                                foreach (XmlNode node in particularWorkFunctionNode.ChildNodes)
                                                {
                                                    if (node.Name == "CodeTF")
                                                    {
                                                        particularWorkFunction.codeTF.Add(node.InnerText);
                                                    }
                                                    else if (node.Name == "NameTF")
                                                    {
                                                        particularWorkFunction.nameTF.Add(node.InnerText);
                                                    }
                                                    else if (node.Name == "SubQualification")
                                                    {
                                                        particularWorkFunction.subQualification.Add(node.InnerText);
                                                    }
                                                    else if (node.Name == "LaborActions")
                                                    {
                                                        foreach (XmlNode actionNode in node.SelectNodes("laborAction"))
                                                        {
                                                            particularWorkFunction.laborActions.laborActions.Add(actionNode.InnerText);
                                                        }
                                                    }
                                                    else if (node.Name == "RequiredSkills")
                                                    {
                                                        foreach (XmlNode skillNode in node.SelectNodes("RequiredSkill"))
                                                        {
                                                            particularWorkFunction.requiredSkills.RequiredSkill.Add(skillNode.InnerText);
                                                        }
                                                    }
                                                    else if (node.Name == "NecessaryKnowledges")
                                                    {
                                                        foreach (XmlNode knowledgeNode in node.SelectNodes("NecessaryKnowledge"))
                                                        {
                                                            particularWorkFunction.necessaryKnowledges.NecessaryKnowledge.Add(knowledgeNode.InnerText);
                                                        }
                                                    }
                                                    else if (node.Name == "OtherCharacteristics")
                                                    {
                                                        foreach (XmlNode otherCharNode in node.SelectNodes("OtherCharacteristic"))
                                                        {
                                                            particularWorkFunction.otherCharacteristics.OtherCharacteristic.Add(otherCharNode.InnerText);
                                                        }
                                                    }
                                                }

                                                particularWorkFunctions.particularWorkFunction.Add(particularWorkFunction);
                                            }

                                            generalizedWorkFunction.ParticularWorkFunctions.Add(particularWorkFunctions);
                                        }
                                    }

                                    generalizedWorkFunctions.generalizedWorkFunctions.Add(generalizedWorkFunction);
                                }
                                thirdSection.WorkFunction.GeneralizedWorkFunctions = generalizedWorkFunctions;
                            }
                        }
                        standart.ThirdSection = thirdSection;
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

                    if (standart.ThirdSection != null)
                    {
                        if (standart.ThirdSection.WorkFunction != null && standart.ThirdSection.WorkFunction.GeneralizedWorkFunctions != null)
                        {
                            foreach (var generalizedWorkFunction in standart.ThirdSection.WorkFunction.GeneralizedWorkFunctions.generalizedWorkFunctions)
                            {
                                Console.WriteLine($"Code OTF: {string.Join(", ", generalizedWorkFunction.CodeOTF)}");
                                Console.WriteLine($"Name OTF: {string.Join(", ", generalizedWorkFunction.NameOTF)}");

                                if (generalizedWorkFunction.PossibleJobTitles != null)
                                {
                                    Console.WriteLine($"Possible Job Titles: {string.Join(", ", generalizedWorkFunction.PossibleJobTitles.PossibleJobTitle)}");
                                }
                                if (generalizedWorkFunction.EducationalRequirements != null)
                                {
                                    Console.WriteLine($"Educational Requirements: {string.Join(", ", generalizedWorkFunction.EducationalRequirements.EducationalRequirement)}");
                                }
                                if (generalizedWorkFunction.RequirementsWorkExperiences != null)
                                {
                                    Console.WriteLine($"Requirements Work Experiences: {string.Join(", ", generalizedWorkFunction.RequirementsWorkExperiences.RequirementsWorkExperience)}");
                                }
                                if (generalizedWorkFunction.SpecialConditionsForAdmissionToWorks != null)
                                {
                                    Console.WriteLine($"Special Conditions For Admission To Works: {string.Join(", ", generalizedWorkFunction.SpecialConditionsForAdmissionToWorks.SpecialConditionForAdmissionToWork)}");
                                }
                                if (generalizedWorkFunction.OtherCharacteristics != null)
                                {
                                    Console.WriteLine($"Other Characteristics: {string.Join(", ", generalizedWorkFunction.OtherCharacteristics.OtherCharacteristic)}");
                                }
                                if (generalizedWorkFunction.OtherCharacteristicPlus != null)
                                {
                                    foreach (var unitOKZ in generalizedWorkFunction.OtherCharacteristicPlus.ListOKZ)
                                    {
                                        Console.WriteLine($"OKZ Code: {unitOKZ.CodeOKZ}, OKZ Name: {unitOKZ.NameOKZ}");
                                    }
                                    foreach (var unitEKS in generalizedWorkFunction.OtherCharacteristicPlus.ListEKS)
                                    {
                                        Console.WriteLine($"EKS Code: {unitEKS.CodeEKS}, EKS Name: {unitEKS.NameEKS}");
                                    }
                                    foreach (var unitOKPDTR in generalizedWorkFunction.OtherCharacteristicPlus.ListOKPDTR)
                                    {
                                        Console.WriteLine($"OKPDTR Code: {unitOKPDTR.CodeOKPDTR}, OKPDTR Name: {unitOKPDTR.NameOKPDTR}");
                                    }
                                    foreach (var unitOKSO in generalizedWorkFunction.OtherCharacteristicPlus.ListOKSO)
                                    {
                                        Console.WriteLine($"OKSO Code: {unitOKSO.CodeOKSO}, OKSO Name: {unitOKSO.NameOKSO}");
                                    }
                                }

                                if (generalizedWorkFunction.ParticularWorkFunctions != null)
                                {
                                    foreach (var particularWorkFunctionGroup in generalizedWorkFunction.ParticularWorkFunctions)
                                    {
                                        foreach (var particularWorkFunction in particularWorkFunctionGroup.particularWorkFunction)
                                        {
                                            Console.WriteLine($"Particular Work Function Code: {string.Join(", ", particularWorkFunction.codeTF)}");
                                            Console.WriteLine($"Particular Work Function Name: {string.Join(", ", particularWorkFunction.nameTF)}");
                                            Console.WriteLine($"Sub Qualification: {string.Join(", ", particularWorkFunction.subQualification)}");
                                            if (particularWorkFunction.laborActions != null)
                                            {
                                                Console.WriteLine($"Labor Actions: {string.Join(", ", particularWorkFunction.laborActions.laborActions)}");
                                            }
                                            if (particularWorkFunction.requiredSkills != null)
                                            {
                                                Console.WriteLine($"Required Skills: {string.Join(", ", particularWorkFunction.requiredSkills.RequiredSkill)}");
                                            }
                                            if (particularWorkFunction.necessaryKnowledges != null)
                                            {
                                                Console.WriteLine($"Necessary Knowledges: {string.Join(", ", particularWorkFunction.necessaryKnowledges.NecessaryKnowledge)}");
                                            }
                                            if (particularWorkFunction.otherCharacteristics != null)
                                            {
                                                Console.WriteLine($"Other Characteristics: {string.Join(", ", particularWorkFunction.otherCharacteristics.OtherCharacteristic)}");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }
            using (StreamWriter sw = new StreamWriter("C:\\Users\\Shispon\\ParserDirectory\\ParserXml\\output.txt"))
            {
                foreach (var standart in standards)
                {
                    sw.WriteLine("ProfessionalStandart:");
                    sw.WriteLine($"  Name: {standart.NameProfessionalStandart}");
                    sw.WriteLine($"  Registration Number: {standart.RegistrationNumber}");
                    sw.WriteLine($"  Order Number: {standart.OrderNumber}");
                    sw.WriteLine($"  Date of Approval: {standart.DateOfApproval}");
                    sw.WriteLine("  First Section:");
                    sw.WriteLine($"    Kind Professional Activity: {standart.FirstSection?.KindProfessionalActivity}");
                    sw.WriteLine($"    Code Kind Professional Activity: {standart.FirstSection?.CodeKindProfessionalActivity}");
                    sw.WriteLine($"    Purpose Kind Professional Activity: {standart.FirstSection?.PurposeKindProfessionalActivity}");

                    if (standart.FirstSection?.EmploymentGroup != null)
                    {
                        sw.WriteLine("    Employment Group:");
                        if (standart.FirstSection.EmploymentGroup.ListOKZ != null)
                        {
                            sw.WriteLine("      List OKZ:");
                            foreach (var unitOKZ in standart.FirstSection.EmploymentGroup.ListOKZ)
                            {
                                sw.WriteLine($"        Code: {unitOKZ.CodeOKZ}, Name: {unitOKZ.NameOKZ}");
                            }
                        }
                        if (standart.FirstSection.EmploymentGroup.ListOKVED != null)
                        {
                            sw.WriteLine("      List OKVED:");
                            foreach (var unitOKVED in standart.FirstSection.EmploymentGroup.ListOKVED)
                            {
                                sw.WriteLine($"        Code: {unitOKVED.CodeOKVED}, Name: {unitOKVED.NameOKVED}");
                            }
                        }
                    }

                    sw.WriteLine("  Third Section:");
                    if (standart.ThirdSection?.WorkFunction?.GeneralizedWorkFunctions != null)
                    {
                        foreach (var genWorkFunction in standart.ThirdSection.WorkFunction.GeneralizedWorkFunctions.generalizedWorkFunctions)
                        {
                            sw.WriteLine("    Generalized Work Function:");
                            sw.WriteLine($"      Code OTF: {string.Join(", ", genWorkFunction.CodeOTF)}");
                            sw.WriteLine($"      Name OTF: {string.Join(", ", genWorkFunction.NameOTF)}");
                            sw.WriteLine("      Possible Job Titles:");
                            foreach (var title in genWorkFunction.PossibleJobTitles.PossibleJobTitle)
                            {
                                sw.WriteLine($"        {title}");
                            }
                            sw.WriteLine("      Educational Requirements:");
                            foreach (var requirement in genWorkFunction.EducationalRequirements.EducationalRequirement)
                            {
                                sw.WriteLine($"        {requirement}");
                            }
                            sw.WriteLine("      Requirements Work Experiences:");
                            foreach (var experience in genWorkFunction.RequirementsWorkExperiences.RequirementsWorkExperience)
                            {
                                sw.WriteLine($"        {experience}");
                            }
                            sw.WriteLine("      Special Conditions For Admission To Works:");
                            foreach (var condition in genWorkFunction.SpecialConditionsForAdmissionToWorks.SpecialConditionForAdmissionToWork)
                            {
                                sw.WriteLine($"        {condition}");
                            }
                            sw.WriteLine("      Other Characteristics:");
                            foreach (var characteristic in genWorkFunction.OtherCharacteristics.OtherCharacteristic)
                            {
                                sw.WriteLine($"        {characteristic}");
                            }
                            sw.WriteLine("      Other Characteristic Plus:");
                            if (genWorkFunction.OtherCharacteristicPlus.ListOKZ != null)
                            {
                                sw.WriteLine("        List OKZ:");
                                foreach (var unitOKZ in genWorkFunction.OtherCharacteristicPlus.ListOKZ)
                                {
                                    sw.WriteLine($"          Code: {unitOKZ.CodeOKZ}, Name: {unitOKZ.NameOKZ}");
                                }
                            }
                            if (genWorkFunction.OtherCharacteristicPlus.ListEKS != null)
                            {
                                sw.WriteLine("        List EKS:");
                                foreach (var unitEKS in genWorkFunction.OtherCharacteristicPlus.ListEKS)
                                {
                                    sw.WriteLine($"          Code: {unitEKS.CodeEKS}, Name: {unitEKS.NameEKS}");
                                }
                            }
                            if (genWorkFunction.OtherCharacteristicPlus.ListOKPDTR != null)
                            {
                                sw.WriteLine("        List OKPDTR:");
                                foreach (var unitOKPDTR in genWorkFunction.OtherCharacteristicPlus.ListOKPDTR)
                                {
                                    sw.WriteLine($"          Code: {unitOKPDTR.CodeOKPDTR}, Name: {unitOKPDTR.NameOKPDTR}");
                                }
                            }
                            if (genWorkFunction.OtherCharacteristicPlus.ListOKSO != null)
                            {
                                sw.WriteLine("        List OKSO:");
                                foreach (var unitOKSO in genWorkFunction.OtherCharacteristicPlus.ListOKSO)
                                {
                                    sw.WriteLine($"          Code: {unitOKSO.CodeOKSO}, Name: {unitOKSO.NameOKSO}");
                                }
                            }
                            sw.WriteLine("      Particular Work Functions:");
                            foreach (var particularWorkFunctions in genWorkFunction.ParticularWorkFunctions)
                            {
                                foreach (var partWorkFunction in particularWorkFunctions.particularWorkFunction)
                                {
                                    sw.WriteLine("        Particular Work Function:");
                                    sw.WriteLine($"          Code TF: {string.Join(", ", partWorkFunction.codeTF)}");
                                    sw.WriteLine($"          Name TF: {string.Join(", ", partWorkFunction.nameTF)}");
                                    sw.WriteLine($"          Sub Qualification: {string.Join(", ", partWorkFunction.subQualification)}");
                                    sw.WriteLine("          Labor Actions:");
                                    foreach (var action in partWorkFunction.laborActions.laborActions)
                                    {
                                        sw.WriteLine($"            {action}");
                                    }
                                    sw.WriteLine("          Required Skills:");
                                    foreach (var skill in partWorkFunction.requiredSkills.RequiredSkill)
                                    {
                                        sw.WriteLine($"            {skill}");
                                    }
                                    sw.WriteLine("          Necessary Knowledges:");
                                    foreach (var knowledge in partWorkFunction.necessaryKnowledges.NecessaryKnowledge)
                                    {
                                        sw.WriteLine($"            {knowledge}");
                                    }
                                    sw.WriteLine("          Other Characteristics:");
                                    foreach (var characteristic in partWorkFunction.otherCharacteristics.OtherCharacteristic)
                                    {
                                        sw.WriteLine($"            {characteristic}");
                                    }
                                }
                            }
                        }
                    }
                    sw.WriteLine();
                }
            }

            Console.WriteLine("Data has been written to output.txt");
        }
    }
}

    

