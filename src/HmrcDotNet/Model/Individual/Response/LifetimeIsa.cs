namespace HmrcDotNet.Model.Individual.Response
{

    public class LifetimeIsa
    {
        public LifetimeIsa()
        {
            _links = new _Links();
        }
        public string LisaManagerReferenceNumber { get; set; }
        public _Links _links { get; set; }
    }

    public class _Links
    {
        public _Links()
        {
            Self = new Self();
            Investors = new Investors();
            CreateortransferAccount = new CreateOrTransferAccount();
            CloseAccount = new CloseAccount();
            Lifeevents = new LifeEvents();
            Bonuspayments= new BonusPayments();
        }

        public Self Self { get; set; }
        public Investors Investors { get; set; }
        public CreateOrTransferAccount CreateortransferAccount { get; set; }
        public CloseAccount CloseAccount { get; set; }
        public LifeEvents Lifeevents { get; set; }
        public BonusPayments Bonuspayments { get; set; }
    }

    public class Self
    {
        public string Href { get; set; }
    }

    public class Investors
    {
        public string Href { get; set; }
    }

    public class CreateOrTransferAccount
    {
        public string Href { get; set; }
    }

    public class CloseAccount
    {
        public string Href { get; set; }
    }

    public class LifeEvents
    {
        public string Href { get; set; }
    }

    public class BonusPayments
    {
        public string Href { get; set; }
    }

}
