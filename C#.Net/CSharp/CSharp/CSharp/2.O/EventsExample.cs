using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.CSharp._2.O
{
    
    class AdmissionInfoEventArgs : EventArgs
    {
        public string GetStudentInfo { get; private set; }      //readonly property
        public string GetCourseInfo { get; private set; }       //readonly property
        public AdmissionInfoEventArgs(string name, string course)
        {
            this.GetStudentInfo = name;
            this.GetCourseInfo = course;
        }
    }
    //this class send info to Director about new admission..
    class InstituteReceptionistPublisher
    {
        //Declaring an event
        public event EventHandler<AdmissionInfoEventArgs> NewAdmissionInfoEvent;
        public void AdmissionInfo(string sname, string course)
        {
            Console.WriteLine("(*) Receptionist: Dear Sir, new admission for Course:{0}.", course);
            Console.WriteLine();
            //checking event is null..
            if (NewAdmissionInfoEvent != null)
            {

                //this event delegate will call such method whose address it contains, having same signature.
                NewAdmissionInfoEvent(this, new AdmissionInfoEventArgs(sname, course));
            }
        }
    }
    //this class to view the new Admission Details..
    class InstituteDirectorSubscriber
    {
        //event listening method..
        public void Get_NewAdmissionInfo(object sender, AdmissionInfoEventArgs e)
        {
            Console.WriteLine("Admission Detail");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Student Name:{0}", e.GetStudentInfo);
            Console.WriteLine("CourseName:{0}", e.GetCourseInfo);
        }
    }
    public class EventsExample
    {
        public static void CallEvents()
        {
            var publishInfo = new InstituteReceptionistPublisher();
            var student = new InstituteDirectorSubscriber();

            //Binding the address of function to event delegate..
            publishInfo.NewAdmissionInfoEvent += student.Get_NewAdmissionInfo;
            
            publishInfo.AdmissionInfo("Ranjeet", "MCA");

            //Releasing the address of function from event delegate..
            publishInfo.NewAdmissionInfoEvent -= student.Get_NewAdmissionInfo;


            publishInfo.NewAdmissionInfoEvent += new InstituteDirectorSubscriber().Get_NewAdmissionInfo;
            publishInfo.AdmissionInfo("Mandan", "CS");
        }
    }
}
