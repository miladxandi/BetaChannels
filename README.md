# Beta Channels - پلتفرم فریلنسری دیجیتال مارکتینگ

## ساختار پروژه

```
BetaChannels/
├── BetaChannels.slnx                    # Solution File
├── BetaChannels.Shared/                 # کتابخانه مشترک
│   ├── Enums/                           # 7 enum (UserRole, ServiceCategory, ...)
│   ├── Models/                          # 12 model (User, Freelancer, Employer, ...)
│   ├── DTOs/                            # 7 DTO file
│   ├── Interfaces/                      # 8 interface سرویس
│   ├── Services/                        # 8 Mock Service
│   ── Helpers/                         # Constants + Extensions
├── BetaChannels.Freelancer/             # اپ فریلنسر
│   ├── Pages/
│   │   ├── Auth/                        # Login, Register
│   │   ├── Dashboard/                   # داشبورد فریلنسر
│   │   ├── Services/                    # مدیریت خدمات
│   │   ├── Portfolio/                   # نمونه کارها
│   │   ├── Calendar/                    # تقویم محتوایی
│   │   ├── Payments/                    # پرداخت‌ها
│   │   └── Subscription/               # اشتراک ویژه
│   ├── Components/                      # Layout + Routes
│   ├── Services/                        # AppState
│   └── Platforms/                       # Android, iOS, MacCatalyst, Windows, Tizen
└── BetaChannels.Employer/              # اپ کارفرما
    ├── Pages/
    │   ├── Auth/                        # Login, Register
    │   ├── Dashboard/                   # داشبورد کارفرما
    │   ├── Freelancers/                 # جستجو و استخدام فریلنسر
    │   ├── Projects/                    # مدیریت پروژه‌ها
    │   └── Payments/                    # پرداخت‌ها
    ├── Components/                      # Layout + Routes
    ├── Services/                        # AppState
    └── Platforms/                       # Android, iOS, MacCatalyst, Windows, Tizen
```

## تکنولوژی‌ها

- **.NET MAUI 10** + **Blazor Hybrid**
- **C# 13** / **net10.0**
- **RTL Persian UI** با تم تاریک (مشکی-نارنجی)
- **Bootstrap Icons** برای آیکون‌ها

## امکانات پیاده‌سازی شده (فاز ۱)

### اپ فریلنسر:
- ثبت‌نام و ورود
- داشبورد با آمار درآمد، پروژه‌ها، امتیاز
- مدیریت خدمات (افزودن/ویرایش/حذف)
- نمونه کارها
- تقویم محتوایی با نمایش ماهانه
- پرداخت‌ها و آمار مالی
- اشتراک ویژه (پایه/حرفه‌ای/ویژه)

### اپ کارفرما:
- ثبت‌نام و ورود
- داشبورد با آمار پروژه‌ها و هزینه‌ها
- جستجوی فریلنسر با فیلتر دسته‌بندی و وضعیت
- پروفایل فریلنسر
- ایجاد پروژه جدید
- پرداخت‌ها

## نحوه بیلد

```bash
# روی ویندوز/مک با .NET MAUI workload نصب شده:
dotnet restore
dotnet build -f net10.0-android
dotnet build -f net10.0-ios
dotnet build -f net10.0-maccatalyst
dotnet build -f net10.0-windows10.0.19041.0
```

## پلتفرم‌های پشتیبانی شده

- Android (API 21+)
- iOS (15.0+)
- Mac Catalyst (15.0+)
- Windows (10.0.17763+)
- Tizen (6.5+)
