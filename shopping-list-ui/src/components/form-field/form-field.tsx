export function FormField({ fieldProps }: { fieldProps: FormFieldProps}) {
    return (                
    <fieldset>
        <label>
            <p>{fieldProps.title}</p>
            <input name={fieldProps.id} id={fieldProps.id}/>
        </label>
    </fieldset>)
}


export type FormFieldProps = {
    id: string,
    title: string,
}