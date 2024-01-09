namespace CProd;

public partial class CardPatientComplaint{

    public int? CardPatientId {get; set;}

    public int? TypeComplaintId {get; set;}
    public virtual CardPatient? IdCardPatientNavigation { get; set; }
    public virtual TypeComplaint? IdTypeComplaintNavigation { get; set; }

   

}