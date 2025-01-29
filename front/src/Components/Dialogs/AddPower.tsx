import { DialogContent, DialogDescription, DialogHeader, DialogTitle, DialogTrigger } from "@/src/components/ui/dialog";
import { API } from "@/src/Services/Api";
import { CHero, CPower } from "@/src/types";
import { Dialog } from "@kobalte/core/dialog";
import { createSignal } from "solid-js";
import { createStore } from "solid-js/store";

const [formElements, setFormElements] = createStore<CPower>({
  id:0,
  name:"",
});

function resetForm(){
  setFormElements({
    id:0,
    name:"",
  })
}

const [open, setOpen] = createSignal(false);
const AddPowerDialog = () =>{
  return (
    <Dialog modal={true} open={open()} onOpenChange={setOpen}>
      <DialogTrigger >
        <button class="z-10 h-[2rem] bg-neutral-800 text-neutral-200 rounded-lg shadow text-mono text-sm font-bold px-4 py-[.5rem] hover:bg-[var(--accent)] ">
          <span>Add</span>
        </button>
      </DialogTrigger>
      <DialogContent class="sm:max-w-[425px] select-none">
        <DialogHeader>
          <DialogTitle>Add Power</DialogTitle>
        </DialogHeader>
        <Form/>

      </DialogContent>
    </Dialog>
  )
}


const Form = ()=>{

  function handleSubmit(e:SubmitEvent){
    e.preventDefault()
    API.Powers.Add(formElements.name)
    resetForm()
    setOpen(false)
  }

  return (
    <form onSubmit={handleSubmit} class="flex flex-col gap-4">
      {/* Powers */}
      <div>
        <label class="block text-sm font-medium text-gray-700">Power</label>
        <div  class="flex gap-2 mb-2">
          <input
            type="text"
            required
            onInput={(e) => setFormElements("name", e.currentTarget.value)}
            class="flex-1 p-2 border rounded-md"
            placeholder="Power name"
          />
        </div>
      </div>

      {/* Buttons */}
      <div class="flex justify-end">
        <button
          type="submit"
          class="bg-blue-500 text-white px-4 py-2 rounded-md hover:bg-blue-600"
        >
          Save Power
        </button>
      </div>
    </form>
  )
}

export default AddPowerDialog
