﻿using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using DevExpress.XtraPivotGrid.ViewInfo;
using DevExpress.XtraPivotGrid.Printing;
using DevExpress.PivotGrid.Printing;

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

        protected override FieldMeasures CreateFieldMeasures(PivotGridViewInfoData data, PivotGridAppearancesBase appearances, PivotVisualItems visualItems) {
            return new MyFieldMeasures(data, appearances, visualItems);
        }
    }

    public class MyFieldMeasures : FieldMeasures
    {
        public MyFieldMeasures(PivotGridViewInfoData data, PivotGridAppearancesBase appearances, PivotVisualItems visualItems) : base(data, appearances, visualItems) { }

        protected override int CalculateHeaderHeight(PivotFieldItemBase field)
        {
            return 40;
        }
    }

    public class MyPivotGridPrinter : PivotGridPrinter
    {
        public MyPivotGridPrinter(PivotGridControl pivotGridControl) : base(pivotGridControl) { }


        protected override DevExpress.XtraPrinting.VisualBrick DrawHeaderBrick(PivotFieldItemBase field, System.Drawing.Rectangle bounds)
        {
            return base.DrawHeaderBrick(field, bounds);
        }
        protected override PivotPrintBestFitter CreatePivotPrintBestFitter()
        {
            return new MyPivotPrintBestFitter(Data, this);
        }
    }

    public class MyPivotPrintBestFitter : PivotPrintBestFitter
    {
        public MyPivotPrintBestFitter(PivotGridData data, PivotGridPrinterBase printer)
            : base(data, printer, new MyPrintCellSizeProvider(data, data.VisualItems, printer))
        {
        }
    }

    public class MyPrintCellSizeProvider : PrintCellSizeProvider
    {
        public MyPrintCellSizeProvider(PivotGridData data, PivotVisualItemsBase visualItems, PivotGridPrinterBase printer)
            : base(data, visualItems, printer) { }

        protected override int CalculateHeaderHeight(PivotFieldItemBase field)
        {
            return 40;
            //return base.CalculateHeaderHeight(field);
        }
    }

}
