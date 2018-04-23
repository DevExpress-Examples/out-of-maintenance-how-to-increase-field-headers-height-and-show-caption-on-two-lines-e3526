using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using DevExpress.XtraPivotGrid.ViewInfo;
using DevExpress.XtraPivotGrid.Printing;

namespace WindowsApplication53
{
    public class MyPivotGridControl : PivotGridControl
    {
        public MyPivotGridControl() : base() { }
        public MyPivotGridControl(PivotGridViewInfoData viewInfoData) : base(viewInfoData) { }

        protected override PivotGridViewInfoData CreateData()
        {
            return new MyPivotGridViewInfoData(this);
        }
        protected override PivotGridPrinter CreatePrinter()
        {
            MyPivotGridPrinter printer = new MyPivotGridPrinter(this);
            printer.Owner = this;
            return printer;
        }
    }

    public class MyPivotGridViewInfoData : PivotGridViewInfoData
    {
        public MyPivotGridViewInfoData() : base() { }
        public MyPivotGridViewInfoData(IViewInfoControl control) : base(control) { }
        protected override PivotGridViewInfo CreateViewInfo()
        {
            return new MyPivotGridViewInfo(this);
        }
    }
    public class MyPivotGridViewInfo : PivotGridViewInfo
    {
        public MyPivotGridViewInfo(PivotGridViewInfoData data) : base(data) { }

        protected override FieldMeasures CreateFieldMeasures()
        {
            return new MyFieldMeasures(Data, PrintAndPaintAppearance);
        }
    }
    public class MyFieldMeasures : FieldMeasures
    {
        public MyFieldMeasures(PivotGridViewInfoData data, PivotGridAppearancesBase appearances) : base(data, appearances) { }
        protected override int CalculateHeaderHeight(PivotFieldItemBase field)
        {
            return 40;
        }
        protected override int CalculateDefaultHeaderHeight()
        {
            return 40;
        }


    }

    public class MyPivotGridPrintViewInfo : PivotGridPrintViewInfo
    {
        public MyPivotGridPrintViewInfo(PivotGridViewInfoData data, bool isPSOwner) : base(data, isPSOwner) { }
        protected override FieldMeasures CreateFieldMeasures()
        {
            return new MyFieldMeasuresPrinting(Data, PrintAndPaintAppearance);
        }

    }
    public class MyFieldMeasuresPrinting : FieldMeasuresPrinting
    {
        public MyFieldMeasuresPrinting(PivotGridViewInfoData data, PivotGridAppearancesBase appearances) : base(data, appearances) { }
        protected override int CalculateDefaultHeaderHeight()
        {
            return 40;
        }
        protected override int CalculateHeaderHeight(PivotFieldItemBase field)
        {
            return 40;
        }
    }

    public class MyPivotGridPrinter : PivotGridPrinter
    {
        public MyPivotGridPrinter(PivotGridControl pivotGridControl) : base(pivotGridControl) { }
        protected override PivotGridPrintViewInfo CreateViewInfo(PivotGridViewInfoData data)
        {
            return new MyPivotGridPrintViewInfo(data, true);
        }
    }

}
