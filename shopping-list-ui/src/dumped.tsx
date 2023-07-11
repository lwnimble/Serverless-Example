// 'use client'
// import { useReducer, useState } from "react";


// const formReducer = (state, event) => {
//     return {
//         ...state,
//         [event.name]: event.value
//     };
// }


// export default function CreateRecipe() {
//     const [formData, setFormData] = useReducer(formReducer, {});
//     const [submitting, setSubmitting] = useState(false);

//     const handleSubmit = (event: any) => {
//         event.preventDefault();
//         setSubmitting(true);

//         setTimeout(() => {
//             setSubmitting(false)
//         }, 3000);
//     }

//     const handleChange = (event: React.ChangeEvent<any>) => {
//         const isCheckbox = event.target.type === "checkbox";
//         setFormData({
//             name: event.target.name,
//             value: isCheckbox ? event.target.checked : event.target.value 
//         })
//     }
    
//     return (
//         <div className="wrapper">
//             {submitting && 
//                 <div>You are submitting the following:
//                     <ul>
//                         {Object.entries(formData).map(([name, value]) => (
//                             <li key={name}><strong>{name}</strong>:{value.toString()}</li>
//                         ))}
//                     </ul>
//                 </div>
//             }
//             <form onSubmit={handleSubmit}>
//                 <fieldset>
//                     <label>
//                         <p>Name</p>
//                         <input id="name" name="name" onChange={handleChange}/>
//                     </label>
//                 </fieldset>
//                 <fieldset>
//                     <label>
//                         <p>Apples</p>
//                         <select name="apple" onChange={handleChange}>
//                             <option value="">--Please choose an option--</option>
//                             <option value="fuji">Fuji</option>
//                             <option value="johnathon">Johnathon</option>
//                             <option value="honey-crisp">Honey Crisp</option>
//                         </select>
//                     </label>
//                     <label>
//                         <p>Count</p>
//                         <input type="number" name="count" onChange={handleChange} step="1" />
//                     </label>
//                     <label>
//                         <p>Gift Wrap?</p>
//                         <input type="checkbox" name="gift-wrap" onChange={handleChange} />
//                     </label>
//                 </fieldset>
//                 <button type="submit">click me</button>
//             </form>
//         </div>
//     )
// }