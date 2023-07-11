import { ChangeEventHandler } from "react"

export function TextInput({ fieldProps }: { fieldProps: TextInputProps}) {
    return (                
    <fieldset>
        <label>
            <p>{fieldProps.title}</p>
            <input name={fieldProps.id} id={fieldProps.id} onChange={fieldProps.changeEventHandler}/>
        </label>
    </fieldset>)
}


export type TextInputProps = {
    id: string,
    title: string,
    changeEventHandler: ChangeEventHandler
}