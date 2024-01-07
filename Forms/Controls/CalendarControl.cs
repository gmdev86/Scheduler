using System.Globalization;
using System;
using System.Linq;
using System.Windows.Forms;
using Scheduler.Core.Models;
using Scheduler.Core.Services;
using System.ComponentModel;

namespace Scheduler.Forms.Controls
{
    public class CalendarControl : UserControl
    {
        private FlowLayoutPanel flpDayContainer;
        private Button btnPrev;
        private Button btnNext;
        private Label lblMonthYearDisplay;
        private Panel panel36;
        private Label lblSaturday;
        private Label lblFriday;
        private Label lblThursday;
        private Label lblWednesday;
        private Label lblTuesday;
        private Label lblMonday;
        private Label lblSunday;
        private int _month;
        private int _year;
        private BlankDayControl blankDayControl1;
        private DayControl dayControl1;
        private DayControl dayControl2;
        private DayControl dayControl3;
        private DayControl dayControl4;
        private DayControl dayControl5;
        private DayControl dayControl6;
        private BlankDayControl blankDayControl2;
        private DayControl dayControl7;
        private DayControl dayControl8;
        private DayControl dayControl9;
        private DayControl dayControl10;
        private DayControl dayControl11;
        private DayControl dayControl12;
        private BlankDayControl blankDayControl3;
        private DayControl dayControl13;
        private DayControl dayControl14;
        private DayControl dayControl15;
        private DayControl dayControl16;
        private DayControl dayControl17;
        private DayControl dayControl18;
        private BlankDayControl blankDayControl4;
        private DayControl dayControl19;
        private DayControl dayControl20;
        private DayControl dayControl21;
        private DayControl dayControl22;
        private DayControl dayControl23;
        private DayControl dayControl24;
        private BlankDayControl blankDayControl5;
        private DayControl dayControl25;
        private DayControl dayControl26;
        private DayControl dayControl27;
        private DayControl dayControl28;
        private DayControl dayControl29;
        private DayControl dayControl30;
        private BlankDayControl blankDayControl6;
        private DayControl dayControl31;
        private DayControl dayControl32;
        private DayControl dayControl33;
        private DayControl dayControl34;
        private DayControl dayControl35;
        private DayControl dayControl36;
        private int _day;
        private DataService _dataService;
        private BindingList<Appointment> _appointments;

        public CalendarControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.flpDayContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.blankDayControl1 = new Scheduler.BlankDayControl();
            this.dayControl1 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl2 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl3 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl4 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl5 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl6 = new Scheduler.Forms.Controls.DayControl();
            this.blankDayControl2 = new Scheduler.BlankDayControl();
            this.dayControl7 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl8 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl9 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl10 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl11 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl12 = new Scheduler.Forms.Controls.DayControl();
            this.blankDayControl3 = new Scheduler.BlankDayControl();
            this.dayControl13 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl14 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl15 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl16 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl17 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl18 = new Scheduler.Forms.Controls.DayControl();
            this.blankDayControl4 = new Scheduler.BlankDayControl();
            this.dayControl19 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl20 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl21 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl22 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl23 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl24 = new Scheduler.Forms.Controls.DayControl();
            this.blankDayControl5 = new Scheduler.BlankDayControl();
            this.dayControl25 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl26 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl27 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl28 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl29 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl30 = new Scheduler.Forms.Controls.DayControl();
            this.blankDayControl6 = new Scheduler.BlankDayControl();
            this.dayControl31 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl32 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl33 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl34 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl35 = new Scheduler.Forms.Controls.DayControl();
            this.dayControl36 = new Scheduler.Forms.Controls.DayControl();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblMonthYearDisplay = new System.Windows.Forms.Label();
            this.panel36 = new System.Windows.Forms.Panel();
            this.lblSaturday = new System.Windows.Forms.Label();
            this.lblFriday = new System.Windows.Forms.Label();
            this.lblThursday = new System.Windows.Forms.Label();
            this.lblWednesday = new System.Windows.Forms.Label();
            this.lblTuesday = new System.Windows.Forms.Label();
            this.lblMonday = new System.Windows.Forms.Label();
            this.lblSunday = new System.Windows.Forms.Label();
            this.flpDayContainer.SuspendLayout();
            this.panel36.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpDayContainer
            // 
            this.flpDayContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpDayContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flpDayContainer.Controls.Add(this.blankDayControl1);
            this.flpDayContainer.Controls.Add(this.dayControl1);
            this.flpDayContainer.Controls.Add(this.dayControl2);
            this.flpDayContainer.Controls.Add(this.dayControl3);
            this.flpDayContainer.Controls.Add(this.dayControl4);
            this.flpDayContainer.Controls.Add(this.dayControl5);
            this.flpDayContainer.Controls.Add(this.dayControl6);
            this.flpDayContainer.Controls.Add(this.blankDayControl2);
            this.flpDayContainer.Controls.Add(this.dayControl7);
            this.flpDayContainer.Controls.Add(this.dayControl8);
            this.flpDayContainer.Controls.Add(this.dayControl9);
            this.flpDayContainer.Controls.Add(this.dayControl10);
            this.flpDayContainer.Controls.Add(this.dayControl11);
            this.flpDayContainer.Controls.Add(this.dayControl12);
            this.flpDayContainer.Controls.Add(this.blankDayControl3);
            this.flpDayContainer.Controls.Add(this.dayControl13);
            this.flpDayContainer.Controls.Add(this.dayControl14);
            this.flpDayContainer.Controls.Add(this.dayControl15);
            this.flpDayContainer.Controls.Add(this.dayControl16);
            this.flpDayContainer.Controls.Add(this.dayControl17);
            this.flpDayContainer.Controls.Add(this.dayControl18);
            this.flpDayContainer.Controls.Add(this.blankDayControl4);
            this.flpDayContainer.Controls.Add(this.dayControl19);
            this.flpDayContainer.Controls.Add(this.dayControl20);
            this.flpDayContainer.Controls.Add(this.dayControl21);
            this.flpDayContainer.Controls.Add(this.dayControl22);
            this.flpDayContainer.Controls.Add(this.dayControl23);
            this.flpDayContainer.Controls.Add(this.dayControl24);
            this.flpDayContainer.Controls.Add(this.blankDayControl5);
            this.flpDayContainer.Controls.Add(this.dayControl25);
            this.flpDayContainer.Controls.Add(this.dayControl26);
            this.flpDayContainer.Controls.Add(this.dayControl27);
            this.flpDayContainer.Controls.Add(this.dayControl28);
            this.flpDayContainer.Controls.Add(this.dayControl29);
            this.flpDayContainer.Controls.Add(this.dayControl30);
            this.flpDayContainer.Controls.Add(this.blankDayControl6);
            this.flpDayContainer.Controls.Add(this.dayControl31);
            this.flpDayContainer.Controls.Add(this.dayControl32);
            this.flpDayContainer.Controls.Add(this.dayControl33);
            this.flpDayContainer.Controls.Add(this.dayControl34);
            this.flpDayContainer.Controls.Add(this.dayControl35);
            this.flpDayContainer.Controls.Add(this.dayControl36);
            this.flpDayContainer.Location = new System.Drawing.Point(20, 182);
            this.flpDayContainer.Margin = new System.Windows.Forms.Padding(0);
            this.flpDayContainer.Name = "flpDayContainer";
            this.flpDayContainer.Size = new System.Drawing.Size(731, 616);
            this.flpDayContainer.TabIndex = 12;
            // 
            // blankDayControl1
            // 
            this.blankDayControl1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.blankDayControl1.Location = new System.Drawing.Point(2, 2);
            this.blankDayControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.blankDayControl1.Name = "blankDayControl1";
            this.blankDayControl1.Size = new System.Drawing.Size(100, 98);
            this.blankDayControl1.TabIndex = 0;
            // 
            // dayControl1
            // 
            this.dayControl1.BackColor = System.Drawing.Color.White;
            this.dayControl1.Location = new System.Drawing.Point(106, 2);
            this.dayControl1.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl1.Name = "dayControl1";
            this.dayControl1.Size = new System.Drawing.Size(100, 98);
            this.dayControl1.TabIndex = 1;
            // 
            // dayControl2
            // 
            this.dayControl2.BackColor = System.Drawing.Color.White;
            this.dayControl2.Location = new System.Drawing.Point(210, 2);
            this.dayControl2.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl2.Name = "dayControl2";
            this.dayControl2.Size = new System.Drawing.Size(100, 98);
            this.dayControl2.TabIndex = 2;
            // 
            // dayControl3
            // 
            this.dayControl3.BackColor = System.Drawing.Color.White;
            this.dayControl3.Location = new System.Drawing.Point(314, 2);
            this.dayControl3.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl3.Name = "dayControl3";
            this.dayControl3.Size = new System.Drawing.Size(100, 98);
            this.dayControl3.TabIndex = 3;
            // 
            // dayControl4
            // 
            this.dayControl4.BackColor = System.Drawing.Color.White;
            this.dayControl4.Location = new System.Drawing.Point(418, 2);
            this.dayControl4.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl4.Name = "dayControl4";
            this.dayControl4.Size = new System.Drawing.Size(100, 98);
            this.dayControl4.TabIndex = 4;
            // 
            // dayControl5
            // 
            this.dayControl5.BackColor = System.Drawing.Color.White;
            this.dayControl5.Location = new System.Drawing.Point(522, 2);
            this.dayControl5.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl5.Name = "dayControl5";
            this.dayControl5.Size = new System.Drawing.Size(100, 98);
            this.dayControl5.TabIndex = 5;
            // 
            // dayControl6
            // 
            this.dayControl6.BackColor = System.Drawing.Color.White;
            this.dayControl6.Location = new System.Drawing.Point(626, 2);
            this.dayControl6.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl6.Name = "dayControl6";
            this.dayControl6.Size = new System.Drawing.Size(100, 98);
            this.dayControl6.TabIndex = 6;
            // 
            // blankDayControl2
            // 
            this.blankDayControl2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.blankDayControl2.Location = new System.Drawing.Point(2, 104);
            this.blankDayControl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.blankDayControl2.Name = "blankDayControl2";
            this.blankDayControl2.Size = new System.Drawing.Size(100, 98);
            this.blankDayControl2.TabIndex = 7;
            // 
            // dayControl7
            // 
            this.dayControl7.BackColor = System.Drawing.Color.White;
            this.dayControl7.Location = new System.Drawing.Point(106, 104);
            this.dayControl7.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl7.Name = "dayControl7";
            this.dayControl7.Size = new System.Drawing.Size(100, 98);
            this.dayControl7.TabIndex = 8;
            // 
            // dayControl8
            // 
            this.dayControl8.BackColor = System.Drawing.Color.White;
            this.dayControl8.Location = new System.Drawing.Point(210, 104);
            this.dayControl8.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl8.Name = "dayControl8";
            this.dayControl8.Size = new System.Drawing.Size(100, 98);
            this.dayControl8.TabIndex = 9;
            // 
            // dayControl9
            // 
            this.dayControl9.BackColor = System.Drawing.Color.White;
            this.dayControl9.Location = new System.Drawing.Point(314, 104);
            this.dayControl9.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl9.Name = "dayControl9";
            this.dayControl9.Size = new System.Drawing.Size(100, 98);
            this.dayControl9.TabIndex = 10;
            // 
            // dayControl10
            // 
            this.dayControl10.BackColor = System.Drawing.Color.White;
            this.dayControl10.Location = new System.Drawing.Point(418, 104);
            this.dayControl10.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl10.Name = "dayControl10";
            this.dayControl10.Size = new System.Drawing.Size(100, 98);
            this.dayControl10.TabIndex = 11;
            // 
            // dayControl11
            // 
            this.dayControl11.BackColor = System.Drawing.Color.White;
            this.dayControl11.Location = new System.Drawing.Point(522, 104);
            this.dayControl11.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl11.Name = "dayControl11";
            this.dayControl11.Size = new System.Drawing.Size(100, 98);
            this.dayControl11.TabIndex = 12;
            // 
            // dayControl12
            // 
            this.dayControl12.BackColor = System.Drawing.Color.White;
            this.dayControl12.Location = new System.Drawing.Point(626, 104);
            this.dayControl12.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl12.Name = "dayControl12";
            this.dayControl12.Size = new System.Drawing.Size(100, 98);
            this.dayControl12.TabIndex = 13;
            // 
            // blankDayControl3
            // 
            this.blankDayControl3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.blankDayControl3.Location = new System.Drawing.Point(2, 206);
            this.blankDayControl3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.blankDayControl3.Name = "blankDayControl3";
            this.blankDayControl3.Size = new System.Drawing.Size(100, 98);
            this.blankDayControl3.TabIndex = 14;
            // 
            // dayControl13
            // 
            this.dayControl13.BackColor = System.Drawing.Color.White;
            this.dayControl13.Location = new System.Drawing.Point(106, 206);
            this.dayControl13.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl13.Name = "dayControl13";
            this.dayControl13.Size = new System.Drawing.Size(100, 98);
            this.dayControl13.TabIndex = 15;
            // 
            // dayControl14
            // 
            this.dayControl14.BackColor = System.Drawing.Color.White;
            this.dayControl14.Location = new System.Drawing.Point(210, 206);
            this.dayControl14.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl14.Name = "dayControl14";
            this.dayControl14.Size = new System.Drawing.Size(100, 98);
            this.dayControl14.TabIndex = 16;
            // 
            // dayControl15
            // 
            this.dayControl15.BackColor = System.Drawing.Color.White;
            this.dayControl15.Location = new System.Drawing.Point(314, 206);
            this.dayControl15.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl15.Name = "dayControl15";
            this.dayControl15.Size = new System.Drawing.Size(100, 98);
            this.dayControl15.TabIndex = 17;
            // 
            // dayControl16
            // 
            this.dayControl16.BackColor = System.Drawing.Color.White;
            this.dayControl16.Location = new System.Drawing.Point(418, 206);
            this.dayControl16.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl16.Name = "dayControl16";
            this.dayControl16.Size = new System.Drawing.Size(100, 98);
            this.dayControl16.TabIndex = 18;
            // 
            // dayControl17
            // 
            this.dayControl17.BackColor = System.Drawing.Color.White;
            this.dayControl17.Location = new System.Drawing.Point(522, 206);
            this.dayControl17.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl17.Name = "dayControl17";
            this.dayControl17.Size = new System.Drawing.Size(100, 98);
            this.dayControl17.TabIndex = 19;
            // 
            // dayControl18
            // 
            this.dayControl18.BackColor = System.Drawing.Color.White;
            this.dayControl18.Location = new System.Drawing.Point(626, 206);
            this.dayControl18.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl18.Name = "dayControl18";
            this.dayControl18.Size = new System.Drawing.Size(100, 98);
            this.dayControl18.TabIndex = 20;
            // 
            // blankDayControl4
            // 
            this.blankDayControl4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.blankDayControl4.Location = new System.Drawing.Point(2, 308);
            this.blankDayControl4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.blankDayControl4.Name = "blankDayControl4";
            this.blankDayControl4.Size = new System.Drawing.Size(100, 98);
            this.blankDayControl4.TabIndex = 21;
            // 
            // dayControl19
            // 
            this.dayControl19.BackColor = System.Drawing.Color.White;
            this.dayControl19.Location = new System.Drawing.Point(106, 308);
            this.dayControl19.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl19.Name = "dayControl19";
            this.dayControl19.Size = new System.Drawing.Size(100, 98);
            this.dayControl19.TabIndex = 22;
            // 
            // dayControl20
            // 
            this.dayControl20.BackColor = System.Drawing.Color.White;
            this.dayControl20.Location = new System.Drawing.Point(210, 308);
            this.dayControl20.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl20.Name = "dayControl20";
            this.dayControl20.Size = new System.Drawing.Size(100, 98);
            this.dayControl20.TabIndex = 23;
            // 
            // dayControl21
            // 
            this.dayControl21.BackColor = System.Drawing.Color.White;
            this.dayControl21.Location = new System.Drawing.Point(314, 308);
            this.dayControl21.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl21.Name = "dayControl21";
            this.dayControl21.Size = new System.Drawing.Size(100, 98);
            this.dayControl21.TabIndex = 24;
            // 
            // dayControl22
            // 
            this.dayControl22.BackColor = System.Drawing.Color.White;
            this.dayControl22.Location = new System.Drawing.Point(418, 308);
            this.dayControl22.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl22.Name = "dayControl22";
            this.dayControl22.Size = new System.Drawing.Size(100, 98);
            this.dayControl22.TabIndex = 25;
            // 
            // dayControl23
            // 
            this.dayControl23.BackColor = System.Drawing.Color.White;
            this.dayControl23.Location = new System.Drawing.Point(522, 308);
            this.dayControl23.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl23.Name = "dayControl23";
            this.dayControl23.Size = new System.Drawing.Size(100, 98);
            this.dayControl23.TabIndex = 26;
            // 
            // dayControl24
            // 
            this.dayControl24.BackColor = System.Drawing.Color.White;
            this.dayControl24.Location = new System.Drawing.Point(626, 308);
            this.dayControl24.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl24.Name = "dayControl24";
            this.dayControl24.Size = new System.Drawing.Size(100, 98);
            this.dayControl24.TabIndex = 27;
            // 
            // blankDayControl5
            // 
            this.blankDayControl5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.blankDayControl5.Location = new System.Drawing.Point(2, 410);
            this.blankDayControl5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.blankDayControl5.Name = "blankDayControl5";
            this.blankDayControl5.Size = new System.Drawing.Size(100, 98);
            this.blankDayControl5.TabIndex = 28;
            // 
            // dayControl25
            // 
            this.dayControl25.BackColor = System.Drawing.Color.White;
            this.dayControl25.Location = new System.Drawing.Point(106, 410);
            this.dayControl25.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl25.Name = "dayControl25";
            this.dayControl25.Size = new System.Drawing.Size(100, 98);
            this.dayControl25.TabIndex = 29;
            // 
            // dayControl26
            // 
            this.dayControl26.BackColor = System.Drawing.Color.White;
            this.dayControl26.Location = new System.Drawing.Point(210, 410);
            this.dayControl26.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl26.Name = "dayControl26";
            this.dayControl26.Size = new System.Drawing.Size(100, 98);
            this.dayControl26.TabIndex = 30;
            // 
            // dayControl27
            // 
            this.dayControl27.BackColor = System.Drawing.Color.White;
            this.dayControl27.Location = new System.Drawing.Point(314, 410);
            this.dayControl27.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl27.Name = "dayControl27";
            this.dayControl27.Size = new System.Drawing.Size(100, 98);
            this.dayControl27.TabIndex = 31;
            // 
            // dayControl28
            // 
            this.dayControl28.BackColor = System.Drawing.Color.White;
            this.dayControl28.Location = new System.Drawing.Point(418, 410);
            this.dayControl28.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl28.Name = "dayControl28";
            this.dayControl28.Size = new System.Drawing.Size(100, 98);
            this.dayControl28.TabIndex = 32;
            // 
            // dayControl29
            // 
            this.dayControl29.BackColor = System.Drawing.Color.White;
            this.dayControl29.Location = new System.Drawing.Point(522, 410);
            this.dayControl29.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl29.Name = "dayControl29";
            this.dayControl29.Size = new System.Drawing.Size(100, 98);
            this.dayControl29.TabIndex = 33;
            // 
            // dayControl30
            // 
            this.dayControl30.BackColor = System.Drawing.Color.White;
            this.dayControl30.Location = new System.Drawing.Point(626, 410);
            this.dayControl30.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl30.Name = "dayControl30";
            this.dayControl30.Size = new System.Drawing.Size(100, 98);
            this.dayControl30.TabIndex = 34;
            // 
            // blankDayControl6
            // 
            this.blankDayControl6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.blankDayControl6.Location = new System.Drawing.Point(2, 512);
            this.blankDayControl6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.blankDayControl6.Name = "blankDayControl6";
            this.blankDayControl6.Size = new System.Drawing.Size(100, 98);
            this.blankDayControl6.TabIndex = 35;
            // 
            // dayControl31
            // 
            this.dayControl31.BackColor = System.Drawing.Color.White;
            this.dayControl31.Location = new System.Drawing.Point(106, 512);
            this.dayControl31.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl31.Name = "dayControl31";
            this.dayControl31.Size = new System.Drawing.Size(100, 98);
            this.dayControl31.TabIndex = 36;
            // 
            // dayControl32
            // 
            this.dayControl32.BackColor = System.Drawing.Color.White;
            this.dayControl32.Location = new System.Drawing.Point(210, 512);
            this.dayControl32.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl32.Name = "dayControl32";
            this.dayControl32.Size = new System.Drawing.Size(100, 98);
            this.dayControl32.TabIndex = 37;
            // 
            // dayControl33
            // 
            this.dayControl33.BackColor = System.Drawing.Color.White;
            this.dayControl33.Location = new System.Drawing.Point(314, 512);
            this.dayControl33.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl33.Name = "dayControl33";
            this.dayControl33.Size = new System.Drawing.Size(100, 98);
            this.dayControl33.TabIndex = 38;
            // 
            // dayControl34
            // 
            this.dayControl34.BackColor = System.Drawing.Color.White;
            this.dayControl34.Location = new System.Drawing.Point(418, 512);
            this.dayControl34.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl34.Name = "dayControl34";
            this.dayControl34.Size = new System.Drawing.Size(100, 98);
            this.dayControl34.TabIndex = 39;
            // 
            // dayControl35
            // 
            this.dayControl35.BackColor = System.Drawing.Color.White;
            this.dayControl35.Location = new System.Drawing.Point(522, 512);
            this.dayControl35.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl35.Name = "dayControl35";
            this.dayControl35.Size = new System.Drawing.Size(100, 98);
            this.dayControl35.TabIndex = 40;
            // 
            // dayControl36
            // 
            this.dayControl36.BackColor = System.Drawing.Color.White;
            this.dayControl36.Location = new System.Drawing.Point(626, 512);
            this.dayControl36.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl36.Name = "dayControl36";
            this.dayControl36.Size = new System.Drawing.Size(100, 98);
            this.dayControl36.TabIndex = 41;
            // 
            // btnPrev
            // 
            this.btnPrev.Image = global::Scheduler.Properties.Resources.GoToFirstRow_16x;
            this.btnPrev.Location = new System.Drawing.Point(20, 12);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(180, 45);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "Previous";
            this.btnPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::Scheduler.Properties.Resources.GoToLastRow_16x;
            this.btnNext.Location = new System.Drawing.Point(609, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(142, 45);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblMonthYearDisplay
            // 
            this.lblMonthYearDisplay.AutoSize = true;
            this.lblMonthYearDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthYearDisplay.Location = new System.Drawing.Point(303, 54);
            this.lblMonthYearDisplay.Name = "lblMonthYearDisplay";
            this.lblMonthYearDisplay.Size = new System.Drawing.Size(169, 26);
            this.lblMonthYearDisplay.TabIndex = 21;
            this.lblMonthYearDisplay.Text = "MONTH YEAR";
            this.lblMonthYearDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel36
            // 
            this.panel36.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel36.Controls.Add(this.btnPrev);
            this.panel36.Controls.Add(this.btnNext);
            this.panel36.Location = new System.Drawing.Point(0, 820);
            this.panel36.Margin = new System.Windows.Forms.Padding(0);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(772, 71);
            this.panel36.TabIndex = 20;
            // 
            // lblSaturday
            // 
            this.lblSaturday.AutoSize = true;
            this.lblSaturday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaturday.Location = new System.Drawing.Point(657, 131);
            this.lblSaturday.Name = "lblSaturday";
            this.lblSaturday.Size = new System.Drawing.Size(73, 20);
            this.lblSaturday.TabIndex = 19;
            this.lblSaturday.Text = "Saturday";
            // 
            // lblFriday
            // 
            this.lblFriday.AutoSize = true;
            this.lblFriday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFriday.Location = new System.Drawing.Point(563, 131);
            this.lblFriday.Name = "lblFriday";
            this.lblFriday.Size = new System.Drawing.Size(52, 20);
            this.lblFriday.TabIndex = 18;
            this.lblFriday.Text = "Friday";
            // 
            // lblThursday
            // 
            this.lblThursday.AutoSize = true;
            this.lblThursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThursday.Location = new System.Drawing.Point(449, 131);
            this.lblThursday.Name = "lblThursday";
            this.lblThursday.Size = new System.Drawing.Size(74, 20);
            this.lblThursday.TabIndex = 17;
            this.lblThursday.Text = "Thursday";
            // 
            // lblWednesday
            // 
            this.lblWednesday.AutoSize = true;
            this.lblWednesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWednesday.Location = new System.Drawing.Point(341, 131);
            this.lblWednesday.Name = "lblWednesday";
            this.lblWednesday.Size = new System.Drawing.Size(93, 20);
            this.lblWednesday.TabIndex = 16;
            this.lblWednesday.Text = "Wednesday";
            // 
            // lblTuesday
            // 
            this.lblTuesday.AutoSize = true;
            this.lblTuesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuesday.Location = new System.Drawing.Point(247, 131);
            this.lblTuesday.Name = "lblTuesday";
            this.lblTuesday.Size = new System.Drawing.Size(69, 20);
            this.lblTuesday.TabIndex = 15;
            this.lblTuesday.Text = "Tuesday";
            // 
            // lblMonday
            // 
            this.lblMonday.AutoSize = true;
            this.lblMonday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonday.Location = new System.Drawing.Point(147, 131);
            this.lblMonday.Name = "lblMonday";
            this.lblMonday.Size = new System.Drawing.Size(65, 20);
            this.lblMonday.TabIndex = 14;
            this.lblMonday.Text = "Monday";
            // 
            // lblSunday
            // 
            this.lblSunday.AutoSize = true;
            this.lblSunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSunday.Location = new System.Drawing.Point(52, 131);
            this.lblSunday.Name = "lblSunday";
            this.lblSunday.Size = new System.Drawing.Size(63, 20);
            this.lblSunday.TabIndex = 13;
            this.lblSunday.Text = "Sunday";
            // 
            // CalendarControl
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flpDayContainer);
            this.Controls.Add(this.lblMonthYearDisplay);
            this.Controls.Add(this.panel36);
            this.Controls.Add(this.lblSaturday);
            this.Controls.Add(this.lblFriday);
            this.Controls.Add(this.lblThursday);
            this.Controls.Add(this.lblWednesday);
            this.Controls.Add(this.lblTuesday);
            this.Controls.Add(this.lblMonday);
            this.Controls.Add(this.lblSunday);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CalendarControl";
            this.Size = new System.Drawing.Size(772, 891);
            this.Load += new System.EventHandler(this.CalendarControl_Load);
            this.flpDayContainer.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void DisplayDays()
        {
            DateTime now = DateTime.Now;
            _year = now.Year;
            _month = now.Month;
            _day = now.Day;

            SetupDayContainer();
        }

        private void ReloadData()
        {
            _appointments = _dataService.GetAllAppointments();
            DisplayDays();
        }

        private void SetupDayContainer()
        {
            flpDayContainer.Controls.Clear();
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(_month);
            lblMonthYearDisplay.Text = monthName + " " + _year;
            DateTime startOfMonth = new DateTime(_year, _month, 1);
            int days = DateTime.DaysInMonth(_year, _month);
            int dayOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")) + 1;

            int extraBlanks = 42 - ((dayOfWeek - 1) + days) + 1;

            for (int i = 1; i < dayOfWeek; i++)
            {
                BlankDayControl blankDayControl = new BlankDayControl();
                blankDayControl.Controls["lblDay"].Text = string.Empty;
                flpDayContainer.Controls.Add(blankDayControl);
            }

            for (int i = 1; i <= days; i++)
            {
                DateTime currentDay = new DateTime(_year, _month, i);
                var appointmentsForDay = _appointments.Where(x => x.Start.Date == currentDay.Date).ToList();
                BindingList<Appointment> appointmentForDay = new BindingList<Appointment>(appointmentsForDay);
                DayControl dayControl = new DayControl(_year, _month, i, appointmentForDay, AllowAddEvent(i));
                dayControl.SetDayLabel(i);
                dayControl.AppointmentDeleted += Appointment_Deleted;
                dayControl.AppointmentSaved += Appointment_Saved;

                if (i == _day && _year == DateTime.Now.Year && _month == DateTime.Now.Month)
                {
                    CircleLabel circleLabel = new CircleLabel();
                    var originalLabel = dayControl.Controls["lblDay"];
                    circleLabel.Location = originalLabel.Location;
                    circleLabel.Name = originalLabel.Name;
                    circleLabel.Text = originalLabel.Text;
                    dayControl.Controls.Remove(originalLabel);
                    dayControl.Controls.Add(circleLabel);
                }

                flpDayContainer.Controls.Add(dayControl);
            }

            for (int i = 1; i < extraBlanks; i++)
            {
                BlankDayControl blankDayControl = new BlankDayControl();
                blankDayControl.Controls["lblDay"].Text = string.Empty;
                flpDayContainer.Controls.Add(blankDayControl);
            }
        }

        private bool AllowAddEvent(int day)
        {
            DateTime currentDay = DateTime.Now;
            DateTime check = new DateTime(_year, _month, day);

            if (check >= currentDay.AddDays(-1) && IsWeekday(check))
            {
                return true;
            }

            return false;
        }

        private bool IsWeekday(DateTime date)
        {
            return date.DayOfWeek >= DayOfWeek.Monday && date.DayOfWeek <= DayOfWeek.Friday;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_month < 12)
            {
                _month += 1;
            }
            else
            {
                _month = 1;
                _year += 1;
            }

            SetupDayContainer();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_month > 1)
            {
                _month -= 1;
            }
            else
            {
                _month = 12;
                _year -= 1;
            }

            SetupDayContainer();
        }

        private void Appointment_Deleted(object sender, EventArgs e)
        {
            ReloadData();
            this.Enabled = true;
        }

        private void Appointment_Saved(object sender, EventArgs e)
        {
            ReloadData();
            this.Enabled = true;
        }

        private void CalendarControl_Load(object sender, EventArgs e)
        {
            _dataService = DataService.Instance;
            _appointments = _dataService.GetAllAppointments();
            DisplayDays();
        }
    }
}
