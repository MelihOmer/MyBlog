namespace MyBlog.Web.ToastrResultMessages
{
    public static class Messages
    {

        public static class ArticleMessages
        {

            public static string Add(string articleTitle)
            {
                return $"{articleTitle} Başlıklı Makale Başarıyla Oluşturuldu.";
            }
            public static string Update(string articleTitle)
            {
                return $"{articleTitle} Başlıklı Makale Başarıyla Güncellendi.";
            }
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} Başlıklı Makale Başarıyla Silindi.";
            }
        }


    }
}
