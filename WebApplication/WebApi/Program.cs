var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapControllers();

// app.MapGet("/Shirts",()=>{
//     return "Getting all the shirts";
// });
 
// app.MapGet("/Shirts/{id}",(int id)=>{
//     return $"get Shirt By {id}";
// });

// app.MapPost("/Shirts",()=>{
//     return "shirt has added";
// });

// app.MapPut("/Shirts/{id}",(int id)=>{
//     return $"shirt has been udated {id}";
// });
// app.MapDelete("/Shirts/{id}",(int id)=>{
//     return $"Shirt  has been deleted {id}";
// });


app.Run();

