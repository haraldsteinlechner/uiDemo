namespace KitchenSink

open System
open Aardvark.Base
open Aardvark.Base.Incremental
open KitchenSink

[<AutoOpen>]
module Mutable =

    [<StructuredFormatDisplay("{AsString}")>]
    type MUrdar private(__initial : KitchenSink.Urdar) =
        let mutable __current = __initial
        let _urdar = ResetMod(__initial.urdar)
        
        member x.urdar = _urdar :> IMod<_>
        
        member x.Update(__model : KitchenSink.Urdar) =
            if not (Object.ReferenceEquals(__model, __current)) then
                __current <- __model
                _urdar.Update(__model.urdar)
        
        static member Create(initial) = MUrdar(initial)
        
        override x.ToString() = __current.ToString()
        member private x.AsString = sprintf "%A" __current
    
    
    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module MUrdar =
        let inline urdar (m : MUrdar) = m.urdar
    
    
    
    
    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Urdar =
        [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
        module Lens =
            let urdar =
                { new Lens<KitchenSink.Urdar, Microsoft.FSharp.Core.int>() with
                    override x.Get(r) = r.urdar
                    override x.Set(r,v) = { r with urdar = v }
                    override x.Update(r,f) = { r with urdar = f r.urdar }
                }
    [<StructuredFormatDisplay("{AsString}")>]
    type MModel private(__initial : KitchenSink.Model) =
        let mutable __current = __initial
        let _boxHovered = ResetMod(__initial.boxHovered)
        let _dragging = ResetMod(__initial.dragging)
        let _lastName = ResetMod(__initial.lastName)
        let _elements = ResetList(__initial.elements)
        let _hasD3Hate = ResetMod(__initial.hasD3Hate)
        let _boxScale = ResetMod(__initial.boxScale)
        let _objects = ResetMapMap(__initial.objects, (fun k v -> MUrdar.Create(v)), (fun (m,i) -> m.Update(i)))
        let _lastTime = ResetMod(__initial.lastTime)
        
        member x.boxHovered = _boxHovered :> IMod<_>
        member x.dragging = _dragging :> IMod<_>
        member x.lastName = _lastName :> IMod<_>
        member x.elements = _elements :> alist<_>
        member x.hasD3Hate = _hasD3Hate :> IMod<_>
        member x.boxScale = _boxScale :> IMod<_>
        member x.objects = _objects :> amap<_,_>
        member x.lastTime = _lastTime :> IMod<_>
        
        member x.Update(__model : KitchenSink.Model) =
            if not (Object.ReferenceEquals(__model, __current)) then
                __current <- __model
                _boxHovered.Update(__model.boxHovered)
                _dragging.Update(__model.dragging)
                _lastName.Update(__model.lastName)
                _elements.Update(__model.elements)
                _hasD3Hate.Update(__model.hasD3Hate)
                _boxScale.Update(__model.boxScale)
                _objects.Update(__model.objects)
                _lastTime.Update(__model.lastTime)
        
        static member Create(initial) = MModel(initial)
        
        override x.ToString() = __current.ToString()
        member private x.AsString = sprintf "%A" __current
    
    
    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module MModel =
        let inline boxHovered (m : MModel) = m.boxHovered
        let inline dragging (m : MModel) = m.dragging
        let inline lastName (m : MModel) = m.lastName
        let inline elements (m : MModel) = m.elements
        let inline hasD3Hate (m : MModel) = m.hasD3Hate
        let inline boxScale (m : MModel) = m.boxScale
        let inline objects (m : MModel) = m.objects
        let inline lastTime (m : MModel) = m.lastTime
    
    
    
    
    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Model =
        [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
        module Lens =
            let boxHovered =
                { new Lens<KitchenSink.Model, Microsoft.FSharp.Core.bool>() with
                    override x.Get(r) = r.boxHovered
                    override x.Set(r,v) = { r with boxHovered = v }
                    override x.Update(r,f) = { r with boxHovered = f r.boxHovered }
                }
            let dragging =
                { new Lens<KitchenSink.Model, Microsoft.FSharp.Core.bool>() with
                    override x.Get(r) = r.dragging
                    override x.Set(r,v) = { r with dragging = v }
                    override x.Update(r,f) = { r with dragging = f r.dragging }
                }
            let lastName =
                { new Lens<KitchenSink.Model, Microsoft.FSharp.Core.Option<Microsoft.FSharp.Core.string>>() with
                    override x.Get(r) = r.lastName
                    override x.Set(r,v) = { r with lastName = v }
                    override x.Update(r,f) = { r with lastName = f r.lastName }
                }
            let elements =
                { new Lens<KitchenSink.Model, Aardvark.Base.plist<Microsoft.FSharp.Core.string>>() with
                    override x.Get(r) = r.elements
                    override x.Set(r,v) = { r with elements = v }
                    override x.Update(r,f) = { r with elements = f r.elements }
                }
            let hasD3Hate =
                { new Lens<KitchenSink.Model, Microsoft.FSharp.Core.bool>() with
                    override x.Get(r) = r.hasD3Hate
                    override x.Set(r,v) = { r with hasD3Hate = v }
                    override x.Update(r,f) = { r with hasD3Hate = f r.hasD3Hate }
                }
            let boxScale =
                { new Lens<KitchenSink.Model, Microsoft.FSharp.Core.float>() with
                    override x.Get(r) = r.boxScale
                    override x.Set(r,v) = { r with boxScale = v }
                    override x.Update(r,f) = { r with boxScale = f r.boxScale }
                }
            let objects =
                { new Lens<KitchenSink.Model, Aardvark.Base.hmap<Microsoft.FSharp.Core.string, KitchenSink.Urdar>>() with
                    override x.Get(r) = r.objects
                    override x.Set(r,v) = { r with objects = v }
                    override x.Update(r,f) = { r with objects = f r.objects }
                }
            let lastTime =
                { new Lens<KitchenSink.Model, Aardvark.Base.MicroTime>() with
                    override x.Get(r) = r.lastTime
                    override x.Set(r,v) = { r with lastTime = v }
                    override x.Update(r,f) = { r with lastTime = f r.lastTime }
                }
    [<StructuredFormatDisplay("{AsString}")>]
    type MCameraControllerState private(__initial : KitchenSink.CameraControllerState) =
        let mutable __current = __initial
        let _view = ResetMod(__initial.view)
        let _dragStart = ResetMod(__initial.dragStart)
        let _look = ResetMod(__initial.look)
        let _zoom = ResetMod(__initial.zoom)
        let _pan = ResetMod(__initial.pan)
        let _forward = ResetMod(__initial.forward)
        let _backward = ResetMod(__initial.backward)
        let _left = ResetMod(__initial.left)
        let _right = ResetMod(__initial.right)
        let _moveVec = ResetMod(__initial.moveVec)
        let _lastTime = ResetMod(__initial.lastTime)
        let _stash = ResetMod(__initial.stash)
        
        member x.view = _view :> IMod<_>
        member x.dragStart = _dragStart :> IMod<_>
        member x.look = _look :> IMod<_>
        member x.zoom = _zoom :> IMod<_>
        member x.pan = _pan :> IMod<_>
        member x.forward = _forward :> IMod<_>
        member x.backward = _backward :> IMod<_>
        member x.left = _left :> IMod<_>
        member x.right = _right :> IMod<_>
        member x.moveVec = _moveVec :> IMod<_>
        member x.lastTime = _lastTime :> IMod<_>
        member x.stash = _stash :> IMod<_>
        
        member x.Update(__model : KitchenSink.CameraControllerState) =
            if not (Object.ReferenceEquals(__model, __current)) then
                __current <- __model
                _view.Update(__model.view)
                _dragStart.Update(__model.dragStart)
                _look.Update(__model.look)
                _zoom.Update(__model.zoom)
                _pan.Update(__model.pan)
                _forward.Update(__model.forward)
                _backward.Update(__model.backward)
                _left.Update(__model.left)
                _right.Update(__model.right)
                _moveVec.Update(__model.moveVec)
                _lastTime.Update(__model.lastTime)
                _stash.Update(__model.stash)
        
        static member Create(initial) = MCameraControllerState(initial)
        
        override x.ToString() = __current.ToString()
        member private x.AsString = sprintf "%A" __current
    
    
    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module MCameraControllerState =
        let inline view (m : MCameraControllerState) = m.view
        let inline dragStart (m : MCameraControllerState) = m.dragStart
        let inline look (m : MCameraControllerState) = m.look
        let inline zoom (m : MCameraControllerState) = m.zoom
        let inline pan (m : MCameraControllerState) = m.pan
        let inline forward (m : MCameraControllerState) = m.forward
        let inline backward (m : MCameraControllerState) = m.backward
        let inline left (m : MCameraControllerState) = m.left
        let inline right (m : MCameraControllerState) = m.right
        let inline moveVec (m : MCameraControllerState) = m.moveVec
        let inline lastTime (m : MCameraControllerState) = m.lastTime
        let inline stash (m : MCameraControllerState) = m.stash
    
    
    
    
    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module CameraControllerState =
        [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
        module Lens =
            let view =
                { new Lens<KitchenSink.CameraControllerState, Aardvark.Base.CameraView>() with
                    override x.Get(r) = r.view
                    override x.Set(r,v) = { r with view = v }
                    override x.Update(r,f) = { r with view = f r.view }
                }
            let dragStart =
                { new Lens<KitchenSink.CameraControllerState, Aardvark.Base.V2i>() with
                    override x.Get(r) = r.dragStart
                    override x.Set(r,v) = { r with dragStart = v }
                    override x.Update(r,f) = { r with dragStart = f r.dragStart }
                }
            let look =
                { new Lens<KitchenSink.CameraControllerState, Microsoft.FSharp.Core.bool>() with
                    override x.Get(r) = r.look
                    override x.Set(r,v) = { r with look = v }
                    override x.Update(r,f) = { r with look = f r.look }
                }
            let zoom =
                { new Lens<KitchenSink.CameraControllerState, Microsoft.FSharp.Core.bool>() with
                    override x.Get(r) = r.zoom
                    override x.Set(r,v) = { r with zoom = v }
                    override x.Update(r,f) = { r with zoom = f r.zoom }
                }
            let pan =
                { new Lens<KitchenSink.CameraControllerState, Microsoft.FSharp.Core.bool>() with
                    override x.Get(r) = r.pan
                    override x.Set(r,v) = { r with pan = v }
                    override x.Update(r,f) = { r with pan = f r.pan }
                }
            let forward =
                { new Lens<KitchenSink.CameraControllerState, Microsoft.FSharp.Core.bool>() with
                    override x.Get(r) = r.forward
                    override x.Set(r,v) = { r with forward = v }
                    override x.Update(r,f) = { r with forward = f r.forward }
                }
            let backward =
                { new Lens<KitchenSink.CameraControllerState, Microsoft.FSharp.Core.bool>() with
                    override x.Get(r) = r.backward
                    override x.Set(r,v) = { r with backward = v }
                    override x.Update(r,f) = { r with backward = f r.backward }
                }
            let left =
                { new Lens<KitchenSink.CameraControllerState, Microsoft.FSharp.Core.bool>() with
                    override x.Get(r) = r.left
                    override x.Set(r,v) = { r with left = v }
                    override x.Update(r,f) = { r with left = f r.left }
                }
            let right =
                { new Lens<KitchenSink.CameraControllerState, Microsoft.FSharp.Core.bool>() with
                    override x.Get(r) = r.right
                    override x.Set(r,v) = { r with right = v }
                    override x.Update(r,f) = { r with right = f r.right }
                }
            let moveVec =
                { new Lens<KitchenSink.CameraControllerState, Aardvark.Base.V3i>() with
                    override x.Get(r) = r.moveVec
                    override x.Set(r,v) = { r with moveVec = v }
                    override x.Update(r,f) = { r with moveVec = f r.moveVec }
                }
            let lastTime =
                { new Lens<KitchenSink.CameraControllerState, Microsoft.FSharp.Core.Option<Microsoft.FSharp.Core.float>>() with
                    override x.Get(r) = r.lastTime
                    override x.Set(r,v) = { r with lastTime = v }
                    override x.Update(r,f) = { r with lastTime = f r.lastTime }
                }
            let stash =
                { new Lens<KitchenSink.CameraControllerState, Microsoft.FSharp.Core.Option<KitchenSink.CameraControllerState>>() with
                    override x.Get(r) = r.stash
                    override x.Set(r,v) = { r with stash = v }
                    override x.Update(r,f) = { r with stash = f r.stash }
                }
