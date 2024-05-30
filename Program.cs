var builder = WebApplication.CreateBuilder(args);

// Aggiungi i servizi MVC al container di servizi
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura la pipeline delle richieste HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Assicurati di avere un controller Home e un'azione Error configurati
    app.UseHsts(); // HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // Ridireziona automaticamente le richieste HTTP a HTTPS
app.UseStaticFiles(); // Serve file statici, come JavaScript, CSS e immagini

app.UseRouting(); // Abilita il routing

app.UseAuthorization(); // Abilita il sistema di autorizzazione

// Definisci le route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Stazione}/{action=Index}/{id?}");

app.Run(); // Avvia l'applicazione
