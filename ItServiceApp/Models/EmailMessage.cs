namespace ItServiceApp.Models
{
    public class EmailMessage //Model klasöründe projemizdeki bilgileri,tabloları yani oluşturduğumuz klasör aslında. Bunları oluşturduğumuzda migration yaptığımızda kendi otomatik tablolarımızı oluşturuyor verileri alarak.
    {
        public string[] Contacts { get; set; }
        public string[] Cc { get; set; }
        public string[] Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
