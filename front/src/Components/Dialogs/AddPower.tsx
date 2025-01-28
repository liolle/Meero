import { DialogContent, DialogDescription, DialogHeader, DialogTitle, DialogTrigger } from "@/src/components/ui/dialog";
import { CHero } from "@/src/types";
import { Dialog } from "@kobalte/core/dialog";
import { createSignal } from "solid-js";
import { createStore } from "solid-js/store";

const [formElements, setFormElements] = createStore<CHero>({
  id:0,
  name:"",
  alias:"",
  powers: [],
  bio:"",
  profileImage:""
});

function resetForm(){
  setFormElements({
    id:0,
    name:"",
    alias:"",
    powers: [],
    bio:"",
    profileImage:""
  })
}

const AddPowerDialog = () =>{
  const [open, setOpen] = createSignal(false);
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
    resetForm()
  }

  return (
    <form onSubmit={handleSubmit} class="flex flex-col gap-4">
      {/* Powers */}
      <div>
        <label class="block text-sm font-medium text-gray-700">Power</label>
        <div  class="flex gap-2 mb-2">
          <input
            type="text"
            //onInput={(e) => updatePower(index, "name", e.currentTarget.value)}
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
