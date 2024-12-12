using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NewsApp
{
    public partial class MainForm : Form
    {
        // API anahtarınız ve endpoint URL'si
        private const string apiKey = "f8f67dbc7740ee4753860db873db8f9d"; // Buraya kendi API anahtarınızı yazın
        private const string apiUrl = "https://api.openweathermap.org/data/2.5/weather?lat=44.34&lon=10.99&appid=" + apiKey;



        public MainForm()
        {
            InitializeComponent();
        }

        // Butona tıklama olayı
        private async void btnFetchNews_Click(object sender, EventArgs e)
        {
            await FetchNewsAsync();
        }

        // API'den haber çekme metodu
        private async Task FetchNewsAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);
                    // API'ye GET isteği gönder
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode(); // Başarısız cevap durumlarını kontrol et

                    string jsonString = await response.Content.ReadAsStringAsync();
                    lblError.Text = $"Hata: {response.StatusCode} - {response.ReasonPhrase}\n{jsonString}";

                    MessageBox.Show(jsonString, "API Yanıtı");
                    // JSON verisini C# nesnesine dönüştür
                    var newsData = JsonConvert.DeserializeObject<NewsResponse>(jsonString);

                    // ListBox'a haber başlıklarını ekle
                    lstNews.Items.Clear(); // Önceki verileri temizle
                    foreach (var article in newsData.articles)
                    {
                        lstNews.Items.Add(article.title); // Sadece haber başlığını ekle
                        if (!string.IsNullOrEmpty(article.title))
                        {
                            lstNews.Items.Add(article.title);
                        }
                        else
                        {
                            lstNews.Items.Add("Başlık bulunamadı.");
                        }
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                // HTTP hatalarını burada yakala ve ekrana yazdır
                lblError.Text = $"Hata: {httpEx.Message}";
            }
            catch (Exception ex)
            {
                // Diğer genel hataları burada yakala ve ekrana yazdır
                lblError.Text = $"Genel hata: {ex.Message}";
            }

        // ListBox'tan bir haber seçildiğinde detaylarını göster
        private void lstNews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNews.SelectedIndex != -1) // Eğer bir öğe seçildiyse
            {
                var selectedArticle = ((NewsResponse)lstNews.Tag).articles[lstNews.SelectedIndex];
                MessageBox.Show($"Başlık: {selectedArticle.title}\n\n" +
                                $"Açıklama: {selectedArticle.description}\n\n" +
                                $"URL: {selectedArticle.url}", "Haber Detayları", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }
    }

    // JSON verisini karşılayacak model sınıfı
    public class NewsResponse
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public Article[] articles { get; set; }
    }

    public class Article
    {
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }
}
