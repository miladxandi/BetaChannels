using System.Globalization;
using BetaChannels.Shared.Enums;
using BetaChannels.Shared.Helpers;

namespace BetaChannels.Employer.Converters;

public class FirstCharConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var str = value as string;
        return string.IsNullOrEmpty(str) ? "ک" : str[0].ToString();
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class StatusNameConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is FreelancerStatus status)
            return status.ToPersianName();
        return value?.ToString() ?? "";
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class StatusColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is FreelancerStatus status)
        {
            return status switch
            {
                FreelancerStatus.Available => Color.FromArgb("#1F4CAF50"),
                FreelancerStatus.Busy => Color.FromArgb("#1FFFC107"),
                FreelancerStatus.Offline => Color.FromArgb("#1FB0B0B0"),
                _ => Color.FromArgb("#1FB0B0B0")
            };
        }
        return Color.FromArgb("#1FB0B0B0");
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class StatusTextColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is FreelancerStatus status)
        {
            return status switch
            {
                FreelancerStatus.Available => Color.FromArgb("#4CAF50"),
                FreelancerStatus.Busy => Color.FromArgb("#FFC107"),
                FreelancerStatus.Offline => Color.FromArgb("#8888aa"),
                _ => Color.FromArgb("#8888aa")
            };
        }
        return Color.FromArgb("#8888aa");
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class PriceConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is decimal price)
            return price.FormatPrice();
        return value?.ToString() ?? " تومان";
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class SkillNameConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is ServiceCategory cat)
            return cat.ToPersianName();
        return value?.ToString() ?? "";
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class BoolToOpenColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is true ? Color.FromArgb("#1F4CAF50") : Color.FromArgb("#1FB0B0B0");
    }
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class BoolToOpenTextConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is true ? "باز" : "بسته";
    }
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class BoolToOpenTextColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is true ? Color.FromArgb("#4CAF50") : Color.FromArgb("#8888aa");
    }
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class PaymentStatusNameConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is PaymentStatus status) return status.ToPersianName();
        return value?.ToString() ?? "";
    }
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class PaymentStatusColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is PaymentStatus status)
        {
            return status switch
            {
                PaymentStatus.Completed => Color.FromArgb("#1F4CAF50"),
                PaymentStatus.Pending => Color.FromArgb("#1FFFC107"),
                PaymentStatus.Failed => Color.FromArgb("#1FF44336"),
                _ => Color.FromArgb("#1FB0B0B0")
            };
        }
        return Color.FromArgb("#1FB0B0B0");
    }
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class PaymentStatusTextColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is PaymentStatus status)
        {
            return status switch
            {
                PaymentStatus.Completed => Color.FromArgb("#4CAF50"),
                PaymentStatus.Pending => Color.FromArgb("#FFC107"),
                PaymentStatus.Failed => Color.FromArgb("#F44336"),
                _ => Color.FromArgb("#8888aa")
            };
        }
        return Color.FromArgb("#8888aa");
    }
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
