import { InputProps } from "@/types/props/input-props"

export function TextInput({ fieldProps }: { fieldProps: InputProps}) {
    return (                
    <fieldset>
        <label>
            <p>{fieldProps.title}</p>
            <input 
                name={fieldProps.id} 
                id={fieldProps.id} 
                value={fieldProps.value}
                onChange={fieldProps.changeEventHandler}/>
        </label>
    </fieldset>)
}

