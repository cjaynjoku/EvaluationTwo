// See https://aka.ms/new-console-template for more information

using HospitalManagementSystem.Entity;
using HospitalManagementSystem.Repository.Wrappers;
using HospitalManagementSystem.HospitalEnum;


Hospital ucth = new Hospital();
Drug emVitC = new Drug("emvitc", 500);
Drug flagyl = new Drug("flagyl", 1440);
Drug paracetamol = new Drug("paracetamol", 4440);
Drug ttc = new Drug("ttc", 530);
Drug amartem = new Drug("amartem", 2050);
Drug azithromycin = new Drug("azithromycin", 1200);
Drug multivite = new Drug("multivite", 450);
Drug ciproflox = new Drug("ciproflox", 1545);
Drug ciprotab = new Drug("ciprotab", 1500);
Drug gestid = new Drug("gestid", 200);
Drug novadex = new Drug("novadex", 9000);
Drug abidec = new Drug("abidec", 4750);




List<Drug> drugs = new List<Drug>() {abidec, novadex, gestid, ciprotab, ciproflox, multivite, azithromycin, emVitC, flagyl, paracetamol, ttc, amartem};

Doctor doctor1 = new Doctor("jeff", ucth);
Doctor doctor2 = new Doctor("rita", ucth);
Doctor doctor3 = new Doctor("anselm", ucth);

List<Doctor> doctors = new List<Doctor>() { doctor1, doctor2 };

Nurse nurse1 = new Nurse("rosary", ucth);
Nurse nurse2 = new Nurse("trip", ucth);
List<Nurse> nurses = new List<Nurse>() { nurse1, nurse2 };


Pharmacist pharm1 = new Pharmacist("favour", ucth);
Pharmacist pharm2 = new Pharmacist("tim", ucth);
List<Pharmacist> pharms = new List<Pharmacist>() { pharm1, pharm2 };


Accountant jude = new Accountant("jude", ucth);
Receptionist james = new Receptionist("james", ucth);

MedicalCondition malaria = new MedicalCondition("malaria");
MedicalCondition typhoid = new MedicalCondition("typhoid");
List<MedicalCondition> conditions = new List<MedicalCondition>() { malaria, typhoid };

Patient sam = new Patient("sam", conditions, ucth, 53300, Gender.Male, true);
Patient pita = new Patient("pita", conditions, ucth, 12000, Gender.Male, true);
Patient paul = new Patient("paul", conditions, ucth, 34050, Gender.Male, true);
Patient ann = new Patient("ann", conditions, ucth, 20000, Gender.Female, true);
Patient jane = new Patient("jane", conditions, ucth, 17900, Gender.Female, true);
Patient maxl = new Patient("maxl", conditions, ucth, 200000, Gender.Male, true);
Patient deb = new Patient("deb", conditions, ucth, 50000, Gender.Female, true);
Patient zeph = new Patient("zeph", conditions, ucth, 50450, Gender.Male, true);



Patient truth = new Patient("truth", conditions, ucth, 3450, Gender.Male, false);
Patient perl = new Patient("perl", conditions, ucth, 1900, Gender.Female, false);
Patient abby = new Patient("abby", conditions, ucth,  6700, Gender.Female);
Patient rita = new Patient("rita", conditions, ucth, 9740, Gender.Female);


List<Patient> patients = new List<Patient>() { ann, jane, maxl, truth, zeph, perl, sam, pita, paul, deb, abby, rita };

var consultationCharges = 5000;
var roomFee = 12000;

ucth.Doctors = doctors;
ucth.Nurses = nurses;
ucth.Pharmacists = pharms;
ucth.Receptionist = james;
ucth.Accountant = jude;
ucth.Patients = patients;
ucth.ConsultationCharges = consultationCharges;
ucth.RoomFee = roomFee;
ucth.Drugs = drugs;


// ISession session = NhibernateHelper.OpenSession();

// DoctorRepository docRepo = new DoctorRepository(session);
// docRepo.

UnitOfWork uOfWork = new UnitOfWork();


uOfWork.HospitalRepo.AddEntity(ucth);
uOfWork.DrugRepo.AddEntity(emVitC);
uOfWork.DrugRepo.AddEntity(flagyl);
uOfWork.DoctorRepo.AddEntity(doctor1);
uOfWork.DoctorRepo.AddEntity(doctor2);
uOfWork.NurseRepo.AddEntity(nurse1);
uOfWork.NurseRepo.AddEntity(nurse2);
uOfWork.PharmRepo.AddEntity(pharm1);
uOfWork.PharmRepo.AddEntity(pharm2);
uOfWork.AccountantRepo.AddEntity(jude);
uOfWork.ReceptionistRepo.AddEntity(james);
uOfWork.ConditionRepo.AddEntity(malaria);
uOfWork.ConditionRepo.AddEntity(typhoid);


Appointment appointment1 = new Appointment(doctor1, sam, DateTime.Today.AddDays(5));
Appointment appointment2 = new Appointment(doctor1, pita, DateTime.Today.AddDays(7));

uOfWork.AppointmentRepo.AddEntity(appointment1);
uOfWork.AppointmentRepo.AddEntity(appointment2);






// Patients that will see a doctor on a particular day
var appointment3 = paul.BookAppointment(doctor3, DateTime.Now.AddDays(10));
var appointment4 = deb.BookAppointment(doctor3, DateTime.Now.AddDays(10));
var appointment5 = zeph.BookAppointment(doctor3, DateTime.Now.AddDays(10));




pita.SeeDoctorCheck(pita.Id);
sam.SeeDoctorCheck(sam.Id);
paul.SeeDoctorCheck(paul.Id);
deb.SeeDoctorCheck(deb.Id);
zeph.SeeDoctorCheck(zeph.Id);



// abby and rita are not registered
abby.SeeDoctorCheck(abby.Id);
rita.SeeDoctorCheck(rita.Id);
uOfWork.Commit();


// ann, jane and ,maxl are registered without an appointment
ann.SeeDoctorCheck(ann.Id);
jane.SeeDoctorCheck(jane.Id);
maxl.SeeDoctorCheck(malaria.Id);


// They now have an appointment

abby.SeeDoctorCheck(abby.Id); // abby and rita are now registered and has an appointment
rita.SeeDoctorCheck(rita.Id);
paul.SeeDoctorCheck(paul.Id);

uOfWork.Commit();

ann.SeeDoctorCheck(ann.Id);
jane.SeeDoctorCheck(jane.Id);
maxl.SeeDoctorCheck(maxl.Id);


uOfWork.Commit();



// Query Operations

Console.WriteLine();
// 1. Patients seen on a particular day
var appointmentsOnAParticularDay = uOfWork.AppointmentRepo.GetAll().Where<Appointment>(x => x.Doctor == doctor3 && x.AppointmentTime.Date == DateTime.Now.AddDays(10).Date);
foreach (var appointment in appointmentsOnAParticularDay)
{
    Console.WriteLine(appointment.Patient.Name);
}


Console.WriteLine();
// 2. All patients seen weekly, monthly, quarterly and yearly

var numberOfPatientsSeen = uOfWork.PatientRepo.GetAll().Where<Patient>(x => x.Appointment != null).Count<Patient>();

double noOfPatientsWeekly = numberOfPatientsSeen / 52;
double noOfPatientsMonthly = numberOfPatientsSeen / 12;
double noOfPatientsYearly = numberOfPatientsSeen;

Console.WriteLine(
    $"Patients seen weekly = {noOfPatientsWeekly}" +
    $"Patients seen monthly = {noOfPatientsMonthly}" +
    $"Patients seen yearly = {noOfPatientsYearly}");



Console.WriteLine();

// 3. All Doctors in the hospital
var allDoctors = uOfWork.DoctorRepo.GetAll();
Console.WriteLine("The doctors in the hospital are:");
foreach(var doctor in allDoctors)
{
    Console.WriteLine(doctor.Name);
}



Console.WriteLine();
// 4. All patients in the hospital
var allPatients = uOfWork.PatientRepo.GetAll();
Console.WriteLine("The patients in the hospital are:");
foreach (var patient in allPatients)
{
    Console.WriteLine(patient.Name);
}

Console.WriteLine();
// 5. All registered patients in the hospital
var allRegisteredPatients = uOfWork.PatientRepo.GetAll().Where<Patient>(x => x.Registered == true);
Console.WriteLine("The Registered patients in the hospital are:");
foreach (var patient in allRegisteredPatients)
{
    Console.WriteLine(patient.Name);
}


Console.WriteLine();
// 6. All patients owing the hospital
var bills = uOfWork.BillRepo.GetAll().Where<Bill>(x => x.Remainder < 0);
Console.WriteLine("The patients owing the hospital are:");
foreach (var bill in bills)
{
    Console.WriteLine(bill.Patient.Name);
}



Console.WriteLine();

// 7.. Top ten drugs that are mostly bought
var drugDict = new SortedDictionary<string, int>();
var frequentBills = uOfWork.BillRepo.GetAll();
foreach (var drugBill in frequentBills)
{
    foreach(var drug in drugBill.Drugs)
    {
        if (drugDict.ContainsKey(drug.DrugName))
        {
            drugDict[drug.DrugName]++;
        }
        else
        {
            drugDict[drug.DrugName] = 1;
        }
    }
}
var sortedDict = (from entry in drugDict
                  orderby entry.Value 
                  descending select entry).Take(10);
Console.WriteLine("The 10 drugs that are mostly bought are:");
foreach (var item in sortedDict)
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}


// Extra Queries

// 1. Extracting all Diseases
var allDiseases = uOfWork.ConditionRepo.GetAll();
foreach (var disease in allDiseases)
{
    Console.WriteLine(disease);
}

// 2. Extracting all females

var allFemales = uOfWork.PatientRepo.GetAll().Where<Patient>(x => x.Gender == Gender.Female);
foreach (var female in allFemales)
{
    Console.WriteLine(female.Name);
}

