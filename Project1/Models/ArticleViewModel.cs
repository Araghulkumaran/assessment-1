namespace Project1.Models
{
    public class ArticleViewModel
    {
        public string AutoArtID { get; set; } = string.Empty;
        public string JBM_AutoID { get; set; } = string.Empty;
        public string IntrnlID { get; set; } = string.Empty;
        public string ChapterID { get; set; } = string.Empty;
        public int ActualPages { get; set; }
        public int DeptCode { get; set; }
        public string DeptName { get; set; } = string.Empty;
        public int? VendorID { get; set; }
        public string VendorName { get; set; } = string.Empty;
    }
}
