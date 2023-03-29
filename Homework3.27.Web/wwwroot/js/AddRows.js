
$(() => {
    let NumberRow = 0;
    $("#add-rows").on('click', function () {
        $("#ppl-rows").append(addRow())
    });
    let addRow = function () {
        NumberRow += 1
       return ` <div class="row person-row" style="margin-bottom: 10px;">
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${NumberRow}].firstname" placeholder="First Name" />
            </div>
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${NumberRow}].lastname" placeholder="Last Name" />
            </div>
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${NumberRow}].age" placeholder="Age" />
            </div>
        </div>`
    }
   
})