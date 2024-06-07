using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserXml.Model
{
    class ProfessionalStandart
    {
        public string? NameProfessionalStandart { get; set; } //навзание проф стандарта
        public string? RegistrationNumber { get; set; } // регистрационный номер
        public string? OrderNumber { get; set; } // Номер приказа минимтсерства труда и соц защиты РФ
        public string? DateOfApproval { get; set; } // дата утверждения приказа 
        public FirstSection? FirstSection { get; set; } // первая секция 
        public ThirdSection? ThirdSection { get; set; }
    }

    class FirstSection
    {
        public string? KindProfessionalActivity { get; set; } //общие сведения
        public string? CodeKindProfessionalActivity { get; set; } // код общих сведений 
        public string? PurposeKindProfessionalActivity { get; set; } // Основная цель вида профессиональной деятельности
        public EmploymentGroup? EmploymentGroup { get; set; }
    }

    class EmploymentGroup
    {
        public List<UnitOKZ>? ListOKZ { get; set; }// группа занятий
        public List<UnitOKVED>? ListOKVED { get; set; } // Отнесение к видам экономической деятельности
    }

    class UnitOKZ
    {
        public string? CodeOKZ { get; set; }
        public string? NameOKZ { get; set; }
    }

    class UnitOKVED
    {
        public string? CodeOKVED { get; set; }
        public string? NameOKVED { get; set; }
    }

    class ThirdSection
    {
        public WorkFunctions? WorkFunction { get; set; }
    }

    class WorkFunctions
    {
        public GeneralizedWorkFunctions? GeneralizedWorkFunctions { get; set; }
    }

    class GeneralizedWorkFunctions
    {
        public List<GeneralizedWorkFunction>? generalizedWorkFunctions { get; set; }
    }

    class GeneralizedWorkFunction
    {
        public List<string>? CodeOTF { get; set; }
        public List<string>? NameOTF { get; set; }
        public PossibleJobTitles? PossibleJobTitles { get; set; }
        public EducationalRequirements? EducationalRequirements { get; set; }
        public RequirementsWorkExperiences? RequirementsWorkExperiences { get; set; }
        public SpecialConditionsForAdmissionToWorks? SpecialConditionsForAdmissionToWorks { get; set; }
        public OtherCharacteristics? OtherCharacteristics { get; set; }
        public OtherCharacteristicPlus? OtherCharacteristicPlus { get; set; }
        public List<ParticularWorkFunctions>? ParticularWorkFunctions {  get; set; } 
    }

    class PossibleJobTitles
    {
        public List<string>? PossibleJobTitle { get; set; }
    }

    class EducationalRequirements
    {
        public List<string>? EducationalRequirement { get; set; }
    }

    class RequirementsWorkExperiences
    {
        public List<string>? RequirementsWorkExperience { get; set; }
    }
    class SpecialConditionsForAdmissionToWorks
    {
        public List<string>? SpecialConditionForAdmissionToWork { get; set; }
    }
    class OtherCharacteristics
    {
        public List<string>? OtherCharacteristic { get; set; }
    }

    class OtherCharacteristicPlus
    {
        public List<UnitOKZ>? ListOKZ { get; set; }// группа занятий
        public List<UnitEKS>? ListEKS { get; set;}
        public List<UnitOKPDTR>? ListOKPDTR { get; set; }
        public List<UnitOKSO>? ListOKSO { get; set;}
    }

    class UnitEKS
    {
        public string? CodeEKS { get; set; }
        public string? NameEKS { get; set; }
    }

    class UnitOKPDTR
    {
        public string? CodeOKPDTR { get; set; }
        public string? NameOKPDTR { get; set; }
    }

    class UnitOKSO
    {
        public string? CodeOKSO { get; set; }
        public string? NameOKSO { get; set; }
    }

    class ParticularWorkFunctions
    {
        public List<ParticularWorkFunction>? particularWorkFunction { get; set; }
    }
    class ParticularWorkFunction
    {
        public List<string>? codeTF { get; set; }
        public List<string>? nameTF { get; set; }
        public List<string>? subQualification {  get; set; }
        public LaborActions? laborActions { get; set; }
        public RequiredSkills? requiredSkills { get; set; }
        public NecessaryKnowledges? necessaryKnowledges { get; set; }
        public OtherCharacteristics? otherCharacteristics { get; set; }
    }

    class LaborActions
    {
        public List<string>? laborActions { get; set; }
    }

    class RequiredSkills
    {
        public List<string>? RequiredSkill { get; set; }
    }

    class NecessaryKnowledges
    {
        public List<string>? NecessaryKnowledge { get; set; }
    }

    
}
