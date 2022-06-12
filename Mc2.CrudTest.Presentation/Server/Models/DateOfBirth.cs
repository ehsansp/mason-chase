using System;

namespace Mc2.CrudTest.Presentation.Server.Models
{
    public sealed class DateOfBirth
    {
        private readonly DateTime _value;
        public DateOfBirth(DateTime value)
        {
            if (value.TimeOfDay.TotalSeconds > 0)
                throw new ArgumentException("Date of birth cannot contain a time.", "DateOfBirth");
            if (IsValid(value) == true)
            {
                _value = value;
            }
        }

        public DateOfBirth(int year, int month, int day)
        {
            var value = new DateTime(year, month, day);
            if (IsValid(value) == true)
            {
                _value = value;
            }
        }

        public static bool IsValid(DateTime candidate)
        {
            if (candidate.Date > DateTime.Now.Date)
                throw new ArgumentException("Age is incorrect.", "DateOfBirth");
            return true;
        }

        public DateTime Value
        {
            get
            {
                return _value;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DateOfBirth);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static implicit operator DateTime(DateOfBirth dateOfBirth)
        {
            return dateOfBirth._value;
        }

        public static bool operator ==(DateOfBirth dateOfBirth1, DateOfBirth dateOfBirth2)
        {
            if (!ReferenceEquals(dateOfBirth1, null) &&
                ReferenceEquals(dateOfBirth2, null))
            {
                return false;
            }
            if (ReferenceEquals(dateOfBirth1, null) &&
                 !ReferenceEquals(dateOfBirth2, null))
            {
                return false;
            }
            if (ReferenceEquals(dateOfBirth1, null) &&
                 ReferenceEquals(dateOfBirth2, null))
            {
                return true;
            }
            return dateOfBirth1.Equals(dateOfBirth2);
        }

        public static bool operator !=(DateOfBirth dateOfBirth1, DateOfBirth dateOfBirth2)
        {
            return !(dateOfBirth1 == dateOfBirth2);
        }

        public bool Equals(DateOfBirth other)
        {
            if (ReferenceEquals(other, null))
                return false;
            return _value == other._value;
        }
    }
}
