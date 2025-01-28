import { TooltipContent, TooltipTrigger } from "@/src/components/ui/tooltip"
import { truncate } from "@/src/lib/utils"
import { CPower } from "@/src/types"
import { Tooltip } from "@kobalte/core/tooltip"

export enum SIZE {
  sm,
  md,
  lg
}

interface IPowerBadge{
  power: CPower
  size: SIZE
}

const sizeMap: Record<SIZE, string> = {
  [SIZE.sm]: "text-sm max-w-[5rem]",
  [SIZE.md]: "text-md max-w-[6rem]",
  [SIZE.lg]: "text-lg max-w-[7rem]"
};


const PowerBadge = (props:IPowerBadge)=>{
  return (
    <Tooltip>
      <TooltipTrigger >
        <div class={`flex justify-start items-center  border ${sizeMap[props.size]}  text-gray-600 italic rounded-md  select-none shadow px-2 truncate hover:border-[var(--accent)]`}>
          <span>{truncate(props.power.name)}</span>
        </div>
      </TooltipTrigger>
      {
        props.power.name.length >10 &&
          <TooltipContent>
            <span>{props.power.name}</span>
          </TooltipContent>
      }
    </Tooltip>
  )
}

export default PowerBadge
