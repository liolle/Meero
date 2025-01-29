import MainLayout from "@/src/Pages/Layouts/MainLayout"
import { CPower } from "../types"
import { createSignal, For, onMount } from "solid-js"
import { API } from "../Services/Api"
import AddPowerDialog from "../Components/Dialogs/AddPower"
import PowerBadge, { SIZE } from "../Components/Badges/PowerBadge"

export const [powers,setPowers] = createSignal<Array<CPower>>(null)
const Power = () => {
  onMount(async ()=>{
    try {
      setPowers(await API.Powers.GetAll()) 
    } catch (error) {
      console.log(error) 
    }
  })

  return (
    <MainLayout>
      <div class="h-full w-full flex flex-col  ">
        <div class="flex h-fit flex-col">
          <div class="px-8 sticky left-0 top-0 z-10  backdrop-blur-sm "> 
            <AddPowerDialog/>
          </div>

          <div class="h-[calc(100vh-112px)] w-full   px-8 pt-4  overflow-y-scroll scrollbar-hidden ">
            <div class="flex gap-4 items-start justify-evenly flex-wrap">
              <For each={powers()} fallback={<></>}>
                {(item) => (
                <PowerBadge size={SIZE.lg} power={item} />
                )}
              </For>

            </div>
          </div>
        </div>
      </div>
    </MainLayout>
  )
}

interface IPowerBadge{
  power: CPower
}

export default Power
