import MainLayout from "@/src/Pages/Layouts/MainLayout"
import { createSignal, For, onMount, Setter } from "solid-js"
import { CLocation } from "../types"
import AddLocationDialog from "../Components/Dialogs/AddLocation"
import { truncate } from "../lib/utils"
import { API } from "../Services/Api"
import { Tooltip } from "@kobalte/core/tooltip"
import { TooltipContent, TooltipTrigger } from "../components/ui/tooltip"

export const [locations,setLocations] = createSignal<Array<CLocation>>([])

const sample = [
  new CLocation("123 Main St", "New York", "USA", "https://images.unsplash.com/photo-1496442226666-8d4d0e62e6e9?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8bmV3JTIweW9ya3xlbnwwfHwwfHx8MA%3D%3D", "", false),
  new CLocation("456 Elm St", "Los Angeles", "USA", "https://images.unsplash.com/photo-1580655653885-65763b2597d0?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8bG9zJTIwYW5nZWxlc3xlbnwwfHwwfHx8MA%3D%3D", "", true),
  new CLocation("789 Oak St", "Chicago", "USA", "https://images.unsplash.com/photo-1494522855154-9297ac14b55f?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Y2hpY2Fnb3xlbnwwfHwwfHx8MA%3D%3D", "", false),
]

const Location = () => {
  onMount(async ()=>{
    try {
      setLocations(await API.Location.GetAll()) 
    } catch (error) {
      console.log(error) 
    }
  })

  return (
    <MainLayout>
      <div class="h-full w-full flex flex-col  ">
        <div class="flex h-fit flex-col">
          <div class="px-8 sticky left-0 top-0 z-10  backdrop-blur-sm "> 
            <AddLocationDialog/>
          </div>

          <div class="h-[calc(100vh-112px)] w-full   px-8 pt-4  overflow-y-scroll scrollbar-hidden ">
            <div class="flex gap-4 items-start justify-evenly flex-wrap">
              <For each={locations()} fallback={<></>}>
                {(item) => (
                  <LocationCard location={item}/>
                )}
              </For>

            </div>
          </div>
        </div>
      </div>

    </MainLayout>
  )
}

interface LocationCardProps {
  location: CLocation
  active?: boolean
}

const LocationCard = (props:LocationCardProps)=>{

  function onclick(e:MouseEvent){
    e.preventDefault()
  }

  return (

    <div onclick={onclick}>
      <Tooltip >
        <TooltipTrigger >
          <div style={`background-image: url('${props.location.locationImage}');`} class={`w-[24rem] h-[18rem] bg-center bg-no-repeat bg-cover overflow-hidden relative rounded-2xl shadow-lg hover:shadow-xl transition-shadow cursor-pointer text-mono border select-none hover:border-[var(--accent)] `}>
            <div class="absolute truncate top-2 left-2 max-w-[10rem] font-bold font-mono italic text-lg bg-neutral-800/60 backdrop-blur-none rounded-lg text-neutral-200 px-2">
              <span>{truncate(props.location.address,15)}</span>
            </div>
            <div class="absolute truncate bottom-2 right-2 max-w-[10rem] font-bold font-mono italic text-lg bg-neutral-800/60 backdrop-blur-none rounded-lg text-neutral-200 px-2">
              <span>{truncate(props.location.city,15)}</span>
            </div>
          </div>
        </TooltipTrigger>
        <TooltipContent>

          <span>{`${props.location.address},${props.location.city},${props.location.country}`}</span>
        </TooltipContent>
      </Tooltip>
    </div>

  );  
}

export default Location
