using App_Repository.Interfaces;
using App_Repository.Repositories;
using App_Service.Interfaces;
using App_Service.Services;
using Firebase.Service.Interfaces;
using Firebase.Service.Services;
using ITCenterService;
using Payment.Service.VNPay.Interfaces;
using Payment.Service.VNPay.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

#region Scope
#region Repository
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOwnedCourseRepository, OwnedCourseRepository>();
builder.Services.AddScoped<IOwnedLessonRepository, OwnedLessonRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
#endregion

#region Service
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOwnedCourseService, OwnedCourseService>();
builder.Services.AddScoped<IOwnedLessonService, OwnedLessonService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
#endregion

#region ThirdParty
builder.Services.AddScoped<IFirebaseStorageService, FirebaseStorageService>();
builder.Services.AddScoped<IVNPayService, VNPayService>();
#endregion
#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
