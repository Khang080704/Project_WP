﻿#pragma checksum "F:\Dai hoc\Year 3\LT Window\Project_WP\Project_WP\KeepItFit - Project WinUI\KeepItFit - Project WinUI\View\AddFood.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3D398B2842C93584DAF750FF289B9BFBED2EC4C2DF10E07BE3729E8CE3FC590A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KeepItFit___Project_WinUI.View
{
    partial class AddFood : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2409")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Microsoft.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_ContentControl_Content(global::Microsoft.UI.Xaml.Controls.ContentControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.Content = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(global::Microsoft.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2409")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private partial class AddFood_obj3_Bindings :
            global::Microsoft.UI.Xaml.IDataTemplateExtension,
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IAddFood_Bindings
        {
            private global::KeepItFit___Project_WinUI.ViewModel.Food dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj3;
            private global::Microsoft.UI.Xaml.Controls.CheckBox obj4;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj5;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj6;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj4ContentDisabled = false;
            private static bool isobj5TextDisabled = false;
            private static bool isobj6TextDisabled = false;

            public AddFood_obj3_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 20 && columnNumber == 65)
                {
                    isobj4ContentDisabled = true;
                }
                else if (lineNumber == 21 && columnNumber == 44)
                {
                    isobj5TextDisabled = true;
                }
                else if (lineNumber == 22 && columnNumber == 44)
                {
                    isobj6TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3: // View\AddFood.xaml line 14
                        this.obj3 = new global::System.WeakReference(global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target));
                        break;
                    case 4: // View\AddFood.xaml line 20
                        this.obj4 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.CheckBox>(target);
                        break;
                    case 5: // View\AddFood.xaml line 21
                        this.obj5 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        break;
                    case 6: // View\AddFood.xaml line 22
                        this.obj6 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2409")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            public void DataContextChangedHandler(global::Microsoft.UI.Xaml.FrameworkElement sender, global::Microsoft.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Microsoft.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            var rootElement = (this.obj3.Target as global::Microsoft.UI.Xaml.Controls.Grid);
                            if (rootElement != null)
                            {
                                rootElement.DataContextChanged -= this.DataContextChangedHandler;
                            }
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_(global::WinRT.CastExtensions.As<global::KeepItFit___Project_WinUI.ViewModel.Food>(item), 1 << phase);
            }

            public void Recycle()
            {
            }

            // IAddFood_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::KeepItFit___Project_WinUI.ViewModel.Food>(newDataRoot);
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::KeepItFit___Project_WinUI.ViewModel.Food obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_foodName(obj.foodName, phase);
                        this.Update_foodQuantity(obj.foodQuantity, phase);
                        this.Update_foodUnit(obj.foodUnit, phase);
                    }
                }
            }
            private void Update_foodName(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // View\AddFood.xaml line 20
                    if (!isobj4ContentDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ContentControl_Content(this.obj4, obj, null);
                    }
                }
            }
            private void Update_foodQuantity(global::System.Single obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // View\AddFood.xaml line 21
                    if (!isobj5TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj5, obj.ToString(), null);
                    }
                }
            }
            private void Update_foodUnit(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // View\AddFood.xaml line 22
                    if (!isobj6TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj6, obj, null);
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2409")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private partial class AddFood_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IAddFood_Bindings
        {
            private global::KeepItFit___Project_WinUI.View.AddFood dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.ItemsControl obj9;
            private global::Microsoft.UI.Xaml.Controls.ItemsControl obj10;
            private global::Microsoft.UI.Xaml.Controls.ItemsControl obj11;
            private global::Microsoft.UI.Xaml.Controls.ItemsControl obj12;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj9ItemsSourceDisabled = false;
            private static bool isobj10ItemsSourceDisabled = false;
            private static bool isobj11ItemsSourceDisabled = false;
            private static bool isobj12ItemsSourceDisabled = false;

            private AddFood_obj1_BindingsTracking bindingsTracking;

            public AddFood_obj1_Bindings()
            {
                this.bindingsTracking = new AddFood_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 54 && columnNumber == 15)
                {
                    isobj9ItemsSourceDisabled = true;
                }
                else if (lineNumber == 61 && columnNumber == 16)
                {
                    isobj10ItemsSourceDisabled = true;
                }
                else if (lineNumber == 68 && columnNumber == 12)
                {
                    isobj11ItemsSourceDisabled = true;
                }
                else if (lineNumber == 75 && columnNumber == 12)
                {
                    isobj12ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 9: // View\AddFood.xaml line 53
                        this.obj9 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ItemsControl>(target);
                        this.bindingsTracking.RegisterTwoWayListener_9(this.obj9);
                        break;
                    case 10: // View\AddFood.xaml line 60
                        this.obj10 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ItemsControl>(target);
                        this.bindingsTracking.RegisterTwoWayListener_10(this.obj10);
                        break;
                    case 11: // View\AddFood.xaml line 67
                        this.obj11 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ItemsControl>(target);
                        this.bindingsTracking.RegisterTwoWayListener_11(this.obj11);
                        break;
                    case 12: // View\AddFood.xaml line 74
                        this.obj12 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ItemsControl>(target);
                        this.bindingsTracking.RegisterTwoWayListener_12(this.obj12);
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2409")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IAddFood_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::KeepItFit___Project_WinUI.View.AddFood>(newDataRoot);
                    return true;
                }
                return false;
            }

            public void Activated(object obj, global::Microsoft.UI.Xaml.WindowActivatedEventArgs data)
            {
                this.Initialize();
            }

            public void Loading(global::Microsoft.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::KeepItFit___Project_WinUI.View.AddFood obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_viewModel(obj.viewModel, phase);
                    }
                }
            }
            private void Update_viewModel(global::KeepItFit___Project_WinUI.View.AddFood.DashBoardViewModel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_viewModel_foodRecent(obj.foodRecent, phase);
                        this.Update_viewModel_foodFrequent(obj.foodFrequent, phase);
                        this.Update_viewModel_foodMyFood(obj.foodMyFood, phase);
                        this.Update_viewModel_foodMeal(obj.foodMeal, phase);
                    }
                }
            }
            private void Update_viewModel_foodRecent(global::System.Collections.Generic.List<global::KeepItFit___Project_WinUI.ViewModel.Food> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // View\AddFood.xaml line 53
                    if (!isobj9ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj9, obj, null);
                    }
                }
            }
            private void Update_viewModel_foodFrequent(global::System.Collections.Generic.List<global::KeepItFit___Project_WinUI.ViewModel.Food> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // View\AddFood.xaml line 60
                    if (!isobj10ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj10, obj, null);
                    }
                }
            }
            private void Update_viewModel_foodMyFood(global::System.Collections.Generic.List<global::KeepItFit___Project_WinUI.ViewModel.Food> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // View\AddFood.xaml line 67
                    if (!isobj11ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj11, obj, null);
                    }
                }
            }
            private void Update_viewModel_foodMeal(global::System.Collections.Generic.List<global::KeepItFit___Project_WinUI.ViewModel.Food> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // View\AddFood.xaml line 74
                    if (!isobj12ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj12, obj, null);
                    }
                }
            }
            private void UpdateTwoWay_9_ItemsSource()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.viewModel != null)
                        {
                            this.dataRoot.viewModel.foodRecent = (global::System.Collections.Generic.List<global::KeepItFit___Project_WinUI.ViewModel.Food>)this.obj9.ItemsSource;
                        }
                    }
                }
            }
            private void UpdateTwoWay_10_ItemsSource()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.viewModel != null)
                        {
                            this.dataRoot.viewModel.foodFrequent = (global::System.Collections.Generic.List<global::KeepItFit___Project_WinUI.ViewModel.Food>)this.obj10.ItemsSource;
                        }
                    }
                }
            }
            private void UpdateTwoWay_11_ItemsSource()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.viewModel != null)
                        {
                            this.dataRoot.viewModel.foodMyFood = (global::System.Collections.Generic.List<global::KeepItFit___Project_WinUI.ViewModel.Food>)this.obj11.ItemsSource;
                        }
                    }
                }
            }
            private void UpdateTwoWay_12_ItemsSource()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.viewModel != null)
                        {
                            this.dataRoot.viewModel.foodMeal = (global::System.Collections.Generic.List<global::KeepItFit___Project_WinUI.ViewModel.Food>)this.obj12.ItemsSource;
                        }
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2409")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class AddFood_obj1_BindingsTracking
            {
                private global::System.WeakReference<AddFood_obj1_Bindings> weakRefToBindingObj; 

                public AddFood_obj1_BindingsTracking(AddFood_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<AddFood_obj1_Bindings>(obj);
                }

                public AddFood_obj1_Bindings TryGetBindingObject()
                {
                    AddFood_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                }

                public void RegisterTwoWayListener_9(global::Microsoft.UI.Xaml.Controls.ItemsControl sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Microsoft.UI.Xaml.Controls.ItemsControl.ItemsSourceProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_9_ItemsSource();
                        }
                    });
                }
                public void RegisterTwoWayListener_10(global::Microsoft.UI.Xaml.Controls.ItemsControl sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Microsoft.UI.Xaml.Controls.ItemsControl.ItemsSourceProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_10_ItemsSource();
                        }
                    });
                }
                public void RegisterTwoWayListener_11(global::Microsoft.UI.Xaml.Controls.ItemsControl sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Microsoft.UI.Xaml.Controls.ItemsControl.ItemsSourceProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_11_ItemsSource();
                        }
                    });
                }
                public void RegisterTwoWayListener_12(global::Microsoft.UI.Xaml.Controls.ItemsControl sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Microsoft.UI.Xaml.Controls.ItemsControl.ItemsSourceProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_12_ItemsSource();
                        }
                    });
                }
            }
        }

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2409")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 7: // View\AddFood.xaml line 28
                {
                    this.MainFrame = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Frame>(target);
                }
                break;
            case 8: // View\AddFood.xaml line 29
                {
                    this.meal = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 9: // View\AddFood.xaml line 53
                {
                    this.foodRecentListView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ItemsControl>(target);
                }
                break;
            case 10: // View\AddFood.xaml line 60
                {
                    this.foodFrequentListView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ItemsControl>(target);
                }
                break;
            case 11: // View\AddFood.xaml line 67
                {
                    this.foodMyFoodListView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ItemsControl>(target);
                }
                break;
            case 12: // View\AddFood.xaml line 74
                {
                    this.foodMealListView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ItemsControl>(target);
                }
                break;
            case 13: // View\AddFood.xaml line 44
                {
                    global::Microsoft.UI.Xaml.Controls.Button element13 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element13).Click += this.Button_Click;
                }
                break;
            case 14: // View\AddFood.xaml line 45
                {
                    global::Microsoft.UI.Xaml.Controls.Button element14 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element14).Click += this.Button_Click;
                }
                break;
            case 15: // View\AddFood.xaml line 46
                {
                    global::Microsoft.UI.Xaml.Controls.Button element15 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element15).Click += this.Button_Click;
                }
                break;
            case 16: // View\AddFood.xaml line 47
                {
                    global::Microsoft.UI.Xaml.Controls.Button element16 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element16).Click += this.Button_Click;
                }
                break;
            case 17: // View\AddFood.xaml line 39
                {
                    this.searchBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 18: // View\AddFood.xaml line 40
                {
                    global::Microsoft.UI.Xaml.Controls.Button element18 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element18).Click += this.SearchButton_Click;
                }
                break;
            case 19: // View\AddFood.xaml line 34
                {
                    global::Microsoft.UI.Xaml.Documents.Hyperlink element19 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Documents.Hyperlink>(target);
                    ((global::Microsoft.UI.Xaml.Documents.Hyperlink)element19).Click += this.HyperlinkToAddCaloriesPage_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }


        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2409")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // View\AddFood.xaml line 2
                {                    
                    global::Microsoft.UI.Xaml.Controls.Page element1 = (global::Microsoft.UI.Xaml.Controls.Page)target;
                    AddFood_obj1_Bindings bindings = new AddFood_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            case 3: // View\AddFood.xaml line 14
                {                    
                    global::Microsoft.UI.Xaml.Controls.Grid element3 = (global::Microsoft.UI.Xaml.Controls.Grid)target;
                    AddFood_obj3_Bindings bindings = new AddFood_obj3_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element3.DataContext);
                    element3.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Microsoft.UI.Xaml.DataTemplate.SetExtensionInstance(element3, bindings);
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element3, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

