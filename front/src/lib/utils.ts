import type { ClassValue } from "clsx"
import { clsx } from "clsx"
import { twMerge } from "tailwind-merge"
 
export function cn(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs))
}

export function truncate (value:string,len=10){
  if (value.length<len) {return value}
  value = value.slice(0,8) + "..."
  return value
}
