namespace HmrcDotNet.Model.Individual.Response
{

    public class NationalInsurance
    {
        public NationalInsurance()
        {
            Class1 = new Class1();
            Class2 = new Class2();
        }

        public Class1 Class1 { get; set; }
        public Class2 Class2 { get; set; }
        public bool MaxNICsReached { get; set; }

       
    }

    public class Class1
    {
        public float TotalNICableEarnings { get; set; }
    }

    public class Class2
    {
        public float TotalDue { get; set; }
    }

}

