﻿/* 
 * Task Scheduler Engine
 * Released under the BSD License
 * https://github.com/pettijohn/TaskSchedulerEngine
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace TaskSchedulerEngine
{
    public class ScheduleRule
    {
        public ScheduleRule()
        {
        }

        public ScheduleRule(string name)
        {
            _name = name;
        }

        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(_name))
                {
                    return _name;
                }
                else
                {
                    return Guid.NewGuid().ToString();
                }
            }
            set
            {
                _name = value;
            }
        }
        string _name;


        /// <summary>
        /// Specify the name/unique identifier of the schedule
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ScheduleRule WithName(string name)
        {
            Name = name;
            return this;
        }

        public int[] Months { get { return _months; } }
        int[] _months;
        /// <summary>
        /// List of months, where 1=Jan, or null for any
        /// </summary>
        public ScheduleRule AtMonths(params int[] value)
        {
            _months = value;
            return this;
        }

        public int[] DaysOfMonth { get { return _daysOfMonth; } }
        int[] _daysOfMonth;
        /// <summary>
        /// 1 to 31
        /// </summary>
        public ScheduleRule AtDaysOfMonth(params int[] value)
        {
            _daysOfMonth = value;
            return this;
        }

        public int[] DaysOfWeek { get { return _daysOfWeek; } }
        int[] _daysOfWeek;
        /// <summary>
        /// 0=Sunday, 1=Mon... 6=Saturday
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ScheduleRule AtDaysOfWeek(params int[] value)
        {
            _daysOfWeek = value;
            return this;
        }
        public int[] Hours { get { return _hours; } }
        int[] _hours;
        /// <summary>
        /// 0 (12am, start of the day) to 23 (11pm)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ScheduleRule AtHours(params int[] value)
        {
            _hours = value;
            return this;
        }
        public int[] Minutes { get { return _minutes; } }
        int[] _minutes;
        /// <summary>
        /// 0 to 59
        /// </summary>
        public ScheduleRule AtMinutes(params int[] value)
        {
            _minutes = value;
            return this;
        }
        public int[] Seconds { get { return _seconds; } }
        int[] _seconds;
        /// <summary>
        /// 0 to 59
        /// </summary>
        public ScheduleRule AtSeconds(params int[] value)
        {
            _seconds = value;
            return this;
        }
        public DateTimeKind Kind { get { return _kind; } }
        DateTimeKind _kind = DateTimeKind.Utc;
        public ScheduleRule WithUtc()
        {
            _kind = DateTimeKind.Utc;
            return this;
        }
        public ScheduleRule WithLocalTime()
        {
            _kind = DateTimeKind.Local;
            return this;
        }

        public List<ITask> Tasks { get { return _tasks; } }
        List<ITask> _tasks = new List<ITask>();
        public ScheduleRule Execute(ITask taskInstance)
        {
            _tasks.Add(taskInstance);
            return this;
        }

    }
}