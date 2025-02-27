import { Button, Checkbox, Dialog, DialogContent, DialogTitle, FormControlLabel, IconButton, Paper, Radio, RadioGroup, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TablePagination, TableRow, TextField } from "@mui/material";
import { useEffect, useState } from "react";
import { CreatePatient, GetAllPatients, GetPatientById, RemovePatient, UpdatePatient } from "../Redux/ActionCreater";
import { connect, useDispatch, useSelector } from "react-redux";
import { OpenPopup } from "../Redux/Action";
import CloseIcon from "@mui/icons-material/Close"

const Patient = (props) => {

    const columns = [
        { id: 'id', name: 'Id' },
        { id: 'firstName', name: 'First Name' },
        { id: 'lastName', name: 'Last Name' },
        { id: 'gender', name: 'Gender' },
        { id: 'address', name: 'Address' },
        { id: 'phoneNumber', name: 'Phone #' },
        { id: 'email', name: 'Email' },
        { id: 'insuranceProvider', name: 'Insurance Provider' },
        { id: 'insurancePolicyNumber', name: 'Insurance Policy Number' },
        { id: 'action', name: 'Action' }
    ]

    const dispatch = useDispatch();

    const [id, idchange] = useState(0);
    const [firstName, firstNameChange] = useState('');
    const [lastName, lastNameChange] = useState('');
    const [gender, genderChange] = useState('');
    const [address, addressChange] = useState('');
    const [phoneNumber, phoneNumberChange] = useState('');
    const [email, emailChange] = useState('');
    const [insurancePolicyNumber, insurancePolicyNumberChange] = useState('');
    const [insuranceProvider, insuranceProviderChange] = useState('');

    const [open, openChange] = useState(false);

    const [rowperpage, rowPerPageChange] = useState(5);
    const [page, pageChange] = useState(0);

    const [isedit, isEditChange] = useState(false);
    const [title, titleChange] = useState('Create Patient');

    const editobj = useSelector((state) => state.patient.patientObj);

    useEffect(() => {
        if (Object.keys(editobj).length > 0) {
            idchange(editobj.id);
            firstNameChange(editobj.firstName);
            lastNameChange(editobj.lastName);
            genderChange(editobj.gender);
            phoneNumberChange(editobj.phoneNumber);
            emailChange(editobj.email);
            addressChange(editobj.address);
            insurancePolicyNumberChange(editobj.insurancePolicyNumber);
            insuranceProviderChange(editobj.insuranceProvider);
        } else {
            clearState();
        }

    }, [editobj])

    const handlePageChange = (event, newpage) => {
        pageChange(newpage);
    }

    const handleRowPerPageChange = (event) => {
        rowPerPageChange(+event.target.value);
        pageChange(0);
    }

    const functionAdd = () => {
        isEditChange(false);
        titleChange('Create Patient');
        openPopup();
    }
    const closePopup = () => {
        openChange(false);
    }
    const openPopup = () => {
        openChange(true);
        clearState();
        dispatch(OpenPopup())
    }
    const handleSubmit = (e) => {
        e.preventDefault();
        const _obj = { id, firstName, lastName, gender, email, phoneNumber, address, insuranceProvider, insurancePolicyNumber };
        if (isedit) {
            dispatch(UpdatePatient(_obj));
        } else {
            dispatch(CreatePatient(_obj));
        }
        closePopup();
    }

    const handleEdit = (id) => {
        isEditChange(true);
        titleChange('Update Patient');
        openChange(true);
        dispatch(GetPatientById(id))
    }

    const handleRemove = (id) => {
        if (window.confirm('Do you want to remove?')) {
            dispatch(RemovePatient(id));
        }
    }


    const clearState = () => {
        idchange(0);
        firstNameChange('');
        lastNameChange();
        genderChange('');
        phoneNumberChange('');
        emailChange('');
        phoneNumberChange('');
        addressChange('');
        insurancePolicyNumberChange('');
        insuranceProviderChange('');
    }
    useEffect(() => {
        props.loadPatients();
    }, [])

    return (
        props.patientState.isloading ? <div><h2>Loading.....</h2></div> :
            props.patientState.errormessage ? <div><h2>{props.patientState.errormessage}</h2></div> :
                <div>
                    <Paper sx={{ margin: '1%' }}>
                        <div style={{ margin: '1%' }}>
                            <Button onClick={functionAdd} variant="contained">Add New</Button>
                        </div>
                        <div style={{ margin: '1%' }}>
                            <TableContainer>
                                <Table>
                                    <TableHead>
                                        <TableRow style={{ backgroundColor: 'midnightblue' }}>
                                            {columns.map((column) =>
                                                <TableCell key={column.id} style={{ color: 'white' }}>{column.name}</TableCell>
                                            )}
                                        </TableRow>

                                    </TableHead>
                                    <TableBody>
                                        {props.patientState.patientList &&
                                            props.patientState.patientList
                                                .slice(page * rowperpage, page * rowperpage + rowperpage)
                                                .map((row, i) => {
                                                    return (
                                                        <TableRow key={i}>
                                                            <TableCell>{row.id}</TableCell>
                                                            <TableCell>{row.firstName}</TableCell>
                                                            <TableCell>{row.lastName}</TableCell>
                                                            <TableCell>{row.gender}</TableCell>
                                                            <TableCell>{row.address}</TableCell>
                                                            <TableCell>{row.phoneNumber}</TableCell>
                                                            <TableCell>{row.email}</TableCell>
                                                            <TableCell>{row.insuranceProvider}</TableCell>
                                                            <TableCell>{row.insurancePolicyNumber}</TableCell>
                                                            <TableCell>
                                                                <Button onClick={e => { handleEdit(row.id) }} variant="contained" color="primary">Edit</Button>
                                                                <Button onClick={e => { handleRemove(row.id) }} variant="contained" color="error">Delete</Button>

                                                            </TableCell>
                                                        </TableRow>
                                                    )
                                                })
                                        }

                                    </TableBody>
                                </Table>
                            </TableContainer>
                            <TablePagination
                                rowsPerPageOptions={[2, 5, 10, 20]}
                                rowsPerPage={rowperpage}
                                page={page}
                                count={props.patientState.patientList.length}
                                component={'div'}
                                onPageChange={handlePageChange}
                                onRowsPerPageChange={handleRowPerPageChange}
                            >

                            </TablePagination>
                        </div>
                    </Paper>

                    <Dialog open={open} onClose={closePopup} fullWidth maxWidth="sm">
                        <DialogTitle>
                            <span>{title}</span>
                            <IconButton style={{ float: 'right' }} onClick={closePopup}><CloseIcon color="primary"></CloseIcon></IconButton>
                        </DialogTitle>
                        <DialogContent>
                            <form onSubmit={handleSubmit}>
                                <Stack spacing={2} margin={2}>
                                    <TextField required error={firstName.length === 0} value={firstName} onChange={e => { firstNameChange(e.target.value) }} variant="outlined" label="First Name"></TextField>
                                    <TextField value={lastName} onChange={e => { lastNameChange(e.target.value) }} variant="outlined" label="Last Name"></TextField>
                                    <TextField required error={gender.length === 0} value={gender} onChange={e => { genderChange(e.target.value) }} variant="outlined" label="Gender"></TextField>
                                    <TextField required datatype="email" error={email.length === 0} value={email} onChange={e => { emailChange(e.target.value) }} variant="outlined" label="Email"></TextField>
                                    <TextField required error={phoneNumber.length === 0} value={phoneNumber} onChange={e => { phoneNumberChange(e.target.value) }} variant="outlined" label="Phone"></TextField>
                                    <TextField required multiline error={address.length === 0} maxRows={2} minRows={2} value={address} onChange={e => { addressChange(e.target.value) }} variant="outlined" label="Address"></TextField>
                                    <TextField value={insurancePolicyNumber} onChange={e => { insurancePolicyNumberChange(e.target.value) }} variant="outlined" label="Insurance Policy Nunber"></TextField>
                                    <TextField value={insuranceProvider} onChange={e => { insuranceProviderChange(e.target.value) }} variant="outlined" label="Insurance Provider"></TextField>

                                    <Button variant="contained" type="submit">Submit</Button>
                                </Stack>
                            </form>
                        </DialogContent>
                    </Dialog>
                </div>
    );
}

const mapStatetoProps = (state) => {
    return {

        patientState: state.patient
    }
}

const mapDispatchtoProps = (dispatch) => {
    return {
        loadPatients: () => dispatch(GetAllPatients())
    }
}

export default connect(mapStatetoProps, mapDispatchtoProps)(Patient);