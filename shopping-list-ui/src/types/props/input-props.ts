import { ChangeEventHandler } from "react"

export type InputProps = {
    id: string,
    title: string,
    minValue?: number
    maxValue?: number
    value?: string | number
    changeEventHandler?: ChangeEventHandler
}