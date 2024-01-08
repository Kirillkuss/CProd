namespace CProd;

public partial class RecordPatient{

    public int IdRecord { get; set; }

    public DateTime DateRecord { get; set; }

    public DateTime DateAppointment { get; set; }

    public int NumberRoom { get; set; }

    public Doctor? Doctor { get; set; }

    public int CardPatientId { get; set; }
}