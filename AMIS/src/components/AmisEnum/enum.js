export const gender = {
    boy: 1,
    girl: 2,
};


export const formMode = {
    add: 1,
    update: 0,
    replication: 2,
}


/**
 * Mã lỗi cho employee

 */
 export  const errorValidationMessageEmployee = {
	employeeCode: {
		required: "Mã nhân viên không được trống",
	},
	fullName: {
		required: "Tên nhân viên không được trống",
	},
	departmentId: { required: "Mã đơn vị không được trống" },
	email: {
		required: "Email không được trống",
		format: "Email không hợp lệ",
	},
	common: {
		required: "Vui lòng nhập trường này",
	},
};






