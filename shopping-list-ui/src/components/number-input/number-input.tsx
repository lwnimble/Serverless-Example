import { InputProps } from "@/types/props/input-props";

export function NumberInput({ fieldProps }: { fieldProps: InputProps}) {
    return (                
    <fieldset>
        <label>
            <p>{fieldProps.title}</p>
            <input 
                type="number" 
                min={fieldProps.minValue}
                max={fieldProps.maxValue}
                name={fieldProps.id} 
                value={fieldProps.value}
                id={fieldProps.id} 
                onChange={fieldProps.changeEventHandler}/>
        </label>
    </fieldset>)
}
